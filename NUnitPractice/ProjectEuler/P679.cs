using System;
using System.Collections.Generic;
using ProjectEuler.Tools;

namespace ProjectEuler
{
    //https://projecteuler.net/problem=679
    public class P679
    {
        public string Alphabet
        { get; private set; }
        public string[] Keywords
        { get; private set; }
        private List<string> SubKeywords
        { get; set; }
        private List<WordSequence> WordSeqs
        { get; set; }
        private int MainID
        { get; set; }

        public P679(string alphabet, string[] keywords)
        { 
            this.Keywords = keywords;
            this.CreateAlphabet(alphabet);
        }

        public P679(string[] keywords) 
        {
            this.Keywords = keywords;
            this.CreateAlphabet(keywords);
        }

        public void InitiateWordSequences(int n=0)
        {
            
            this.GenerateSubKeywords();
            this.MainID = this.GenerateWordSeqs();
            Console.WriteLine($"A total of {this.WordSeqs.Count} recursions.");
            for (int i=0; i<n; i++)
                this.AllNextCounts();
        }

        public long f(int n)
        {
            WordSequence mainSeq = this.WordSeqs[this.MainID];
            while (mainSeq.Counts.Count <= n)
                this.AllNextCounts();
            return mainSeq.Counts[n];
        }

        private void GrowAlphabet(string word)
        {
            foreach (char newLetter in word)
                if (!this.Alphabet.Contains(newLetter.ToString()))
                    this.Alphabet += newLetter;
        }

        private void CreateAlphabet(string alphabet)
        {
            this.Alphabet = string.Empty;
            this.GrowAlphabet(alphabet);
        }

        private void CreateAlphabet(string[] keywords)
        {
            this.Alphabet = string.Empty;
            foreach (string keyword in keywords)
                this.GrowAlphabet(keyword);
        }

        private void AddSubKeyword(string newSubKey)
        {
            if (!this.SubKeywords.Contains(newSubKey))
                this.SubKeywords.Add(newSubKey);
            /*
            // This is for when SubKeywords was List<SubKeyword>:
            bool isAlreadyHere = false;
            foreach (string subKey in this.SubKeywords) {
                isAlreadyHere |= (newSubKey == subKey);
                if (isAlreadyHere)
                    break;
            }
            if (!isAlreadyHere)
                this.SubKeywords.Add(newSubKey);
            */
        }

        // Generates all list of all proper initial subwords of the keywords,
        // starting with the empty word.
        private void GenerateSubKeywords()
        {
            this.SubKeywords = new List<string>();

            string subKey;
            foreach (string keyword in this.Keywords) {
                Console.WriteLine($"Keyword: {keyword}");
                for (int i=0; i<keyword.Length; i++) {
                    subKey = keyword.Substring(0, i);
                    //subKeyword = new SubKeyword(subKey);
                    this.AddSubKeyword(subKey);
                    //Console.WriteLine(subKey);
                }
            }
            Console.WriteLine($"A total of {this.SubKeywords.Count} distinct proper initial subwords.");
        }

        private bool[] intToBools(int n, int l)
        {
            int remainder = n;
            bool[] bools = new bool[l];
            for (int i=1; i<=l; i++) {
                bools[l - i] = ((remainder % 2) > 0);
                remainder /= 2;
            }
            return bools;
        }

        private int boolsToInt(bool[] bools)
        {
            int n = 0;
            for (int i=0; i<bools.Length; i++) {
                n *= 2;
                if (bools[i])
                    n += 1;
            }
            return n;
        }

        // If newBools is exactly oldBools, but with 1 entry false instead of true,
        // returns the index of that entry;
        // otherwise, returns -1.
        private int MissingIndex(bool[] oldBools, bool[] newBools)
        {
            if (oldBools.Length != newBools.Length)
                throw new ArgumentException("The two bool[] arguments must be same length.");
            int missingI = -1;
            for (int i=0; i<oldBools.Length; i++) {
                // If an entry has gone from false to true, reject.
                if (!oldBools[i] && newBools[i])
                    return -1;
                // If an entry has gone from true to false, inspect.
                if (oldBools[i] && !newBools[i]) {
                    // If this isn't the first time, reject.
                    if (missingI >= 0)
                        return -1;
                    else
                        missingI = i;
                }
            }
            return missingI;
        }

        private bool HasFinalSubstring(string word, string subword) {
            int longer = word.Length - subword.Length;
            if (longer < 0)
                return false;
            for (int i=0; i<subword.Length; i++)
                if (word[longer + i] != subword[i])
                    return false;
            return true;
        }

        // Generates the list of word-sequences, one for each pair (keyword subset, subkeyword),
        // starting with (empty set, empty word).
        // Returns the ID of the main sequence, with all Keywords present and no specific ending.
        private int GenerateWordSeqs()
        {
            this.WordSeqs = new List<WordSequence>();
            
            // First generate the bare counters.
            int iD;
            bool[] keywordPresence;
            int numberOfSubsets = (int)Math.Pow(2, this.Keywords.Length);
            int mainID = (numberOfSubsets - 1) * this.SubKeywords.Count;
            WordSequence newWordSeq;
            for (int i=0; i<numberOfSubsets; i++) {
                keywordPresence = this.intToBools(i, this.Keywords.Length);
                foreach (string subkey in this.SubKeywords) {
                    iD = this.WordSeqs.Count;
                    newWordSeq = new WordSequence(subkey, keywordPresence, iD);
                    this.WordSeqs.Add(newWordSeq);
                }
            }

            // Then generate the recurrence relations.
            // WARNING: Assumes no keyword is a final subword of another
            // (i.e., no two keywords can be completed simultaneously with the addition of 1 letter).
            WordSequence child;
            WordSequence parent;
            string primaryParentEnding;
            int primaryParentCoefficient;
            int primaryParentKeyInt;
            bool[] possibleKeys;
            List<string> possibleKeysSansEnd;
            int missingKeywordIndex;
            string missingKeyword;
            for (iD=0; iD<this.WordSeqs.Count; iD++) {
                child = this.WordSeqs[iD];
                primaryParentEnding = string.Empty;
                primaryParentCoefficient = this.Alphabet.Length;
                primaryParentKeyInt = this.boolsToInt(child.KeywordPresence);
                possibleKeys = new bool[this.Keywords.Length];
                possibleKeysSansEnd = new List<string>();
                /*if (iD == 0)
                    child.Recursion.AddRecurranceTerm(iD, primaryParentCoefficient);
                else {*/
                if (child.Ending != string.Empty) {
                    primaryParentCoefficient = 1;
                    if (child.Ending.Length > 1)
                        primaryParentEnding = child.Ending.Substring(0, child.Ending.Length - 1);
                }

                // Identify which /*counted*/ keywords are completed with the current child's Ending.
                for (int i=0; i<this.Keywords.Length; i++)
                    if (/*child.KeywordPresence[i] &&*/ this.HasFinalSubstring(this.Keywords[i], child.Ending)) {
                        possibleKeys[i] = true;
                        possibleKeysSansEnd.Add(this.Keywords[i].Substring(0, this.Keywords[i].Length - 1));
                    }
                
                for (int j=0; j<this.WordSeqs.Count; j++) {
                    parent = this.WordSeqs[j];
                    if (parent.Ending == primaryParentEnding) { 
                        // First recurrence case is the primary parent, with:
                        // * the same set of keywords
                        // * ending keyword same as child's without it's final letter removed.
                        if (this.boolsToInt(parent.KeywordPresence) == primaryParentKeyInt)
                            child.Recursion.AddRecurranceTerm(j, primaryParentCoefficient);

                    } else if (possibleKeysSansEnd.Contains(parent.Ending)) {
                        // Second recurrence case is subtracted to cancel unwanted new words.
                        if (this.boolsToInt(parent.KeywordPresence) == primaryParentKeyInt)
                            child.Recursion.AddRecurranceTerm(j, -1);
                        // Third recurrence case has exactly one keyword missing from the set of keywords,
                        // and that keyword is terminated by the child's ending,
                        // and with ending word that keyword without it's final letter.
                        else {
                            missingKeywordIndex = this.MissingIndex(child.KeywordPresence, parent.KeywordPresence);
                            if (missingKeywordIndex >= 0 && possibleKeys[missingKeywordIndex]) {
                                missingKeyword = this.Keywords[missingKeywordIndex];
                                if (missingKeyword.Substring(0, missingKeyword.Length - 1) == parent.Ending)
                                    child.Recursion.AddRecurranceTerm(j, 1);
                            }
                        }
                    }
                }
                /*}*/
                //Console.WriteLine($"iD={iD} #keywords={child.KeywordCount} ending={child.Ending} #possible={possibleKeysSansEnd.Count} #parents={child.Recursion.IDs.Count} primaryParentPresence={primaryParentKeyInt} primaryParentEnding={primaryParentEnding} primaryParentCoef={primaryParentCoefficient}");
                /*if (possibleKeysSansEnd.Count == this.Keywords.Length) {
                    foreach (int recID in child.Recursion.IDs) Console.WriteLine(recID);
                    foreach (int recCoef in child.Recursion.Coefficients) Console.WriteLine(recCoef);
                }*/
            }
            return mainID;
        }

        private void NextCount(WordSequence wordSeq)
        {
            int index = wordSeq.Counts.Count - 1;
            long nextTerm = 0;
            int parentID;
            long parentTerm;
            int terms = wordSeq.Recursion.IDs.Count;
            for (int i=0; i<terms; i++) {
                parentID = wordSeq.Recursion.IDs[i];
                parentTerm = this.WordSeqs[parentID].Counts[index];
                nextTerm += wordSeq.Recursion.Coefficients[i] * parentTerm;
            }
            wordSeq.Counts.Add(nextTerm);
            //if (index>7)// && wordSeq.KeywordCount>0)
            //    Console.WriteLine($"i={index+1} id={wordSeq.ID} ending={wordSeq.Ending} #keys={wordSeq.KeywordCount} count(i)={nextTerm}");
        }

        public void AllNextCounts()
        {
            foreach (WordSequence wordSeq in this.WordSeqs)
                this.NextCount(wordSeq);
        }
        
    }

    /*
    public class SubKeyword : IComparable
    {
        public string Subword
        { get; private set; }
        public int Length
        { get; private set; }

        public SubKeyword(string subword)
        {
            this.Subword = subword;
            this.Length = this.Subword.Length;
        }

        public int CompareTo(object obj) 
        {
            if (obj == null) return 1;
            
            SubKeyword other = obj as SubKeyword;
            if (other != null) {
                return this.CompareTo(other);
            } else {
                throw new ArgumentException("Object is not a Subkeyword");
            }
        }

        public int CompareTo(SubKeyword other)
        {
            if (this.Length < other.Length && this.Subword == other.Subword.Substring(0, this.Length)) {
                return -1;
            } else if (other.Length < this.Length && other.Subword == this.Subword.Substring(0, other.Length)) {
                return 1;
            } else {
                return 0;
            }
        }
    }
    */

    public class WordRecursion
    {
        public List<int> IDs
        { get; private set; }
        public List<int> Coefficients
        { get; private set; }
        //public List<int> Offsets
        //{ get; private set; }

        public WordRecursion()
        {
            IDs = new List<int>();
            Coefficients = new List<int>();
            //Offsets = new List<int>();
        }

        public void AddRecurranceTerm(int iD, int coefficient)//, int offset)
        {
            this.IDs.Add(iD);
            this.Coefficients.Add(coefficient);
            //this.Offsets.Add(offset);
        }

    }

    public class WordSequence
    {
        public string Ending
        { get; private set; }
        public bool[] KeywordPresence
        { get; private set; }
        public int KeywordCount
        { get; private set; }
        public int ID
        { get; private set; }
        public List<long> Counts
        { get; set; }
        public WordRecursion Recursion
        { get; set; }

        public WordSequence(string ending, bool[] keywordPresence, int iD)
        {
            this.Ending = ending;
            this.KeywordPresence = keywordPresence;
            this.KeywordCount = 0;
            foreach (bool present in this.KeywordPresence)
                if (present) 
                    this.KeywordCount++;
            this.ID = iD;
            this.Counts = new List<long>(){};
            if (this.Ending.Length == 0 && this.KeywordCount == 0)
                this.Counts.Add(1);
            else
                this.Counts.Add(0);
            this.Recursion = new WordRecursion();
        }

    }

}