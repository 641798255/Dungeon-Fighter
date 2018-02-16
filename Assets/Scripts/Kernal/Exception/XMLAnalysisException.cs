/*
   Title :
   主题：
   功能：
*/
using UnityEngine;
using System.Collections;
using System;

namespace Kernal
{
    public class XMLAnalysisExption : Exception {
        public XMLAnalysisExption() : base() { }
        public XMLAnalysisExption(string exceptionMessage) : base(exceptionMessage) { }
    }
}


