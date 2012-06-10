﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Package;
using Microsoft.VisualStudio.TextManager.Interop;
using Microsoft.VisualStudio.OLE.Interop;

// Walkthrough: Creating a Language Service (MPF)
//   http://msdn.microsoft.com/en-us/library/bb165744
// Language Service Features (MPF)
//   http://msdn.microsoft.com/en-us/library/bb166215
// Syntax Colorizing
//   http://msdn.microsoft.com/en-us/library/bb165041

namespace Cosmos.VS.XSharp {
  public class XSharpLanguageService : LanguageService {
    public override string GetFormatFilterList() {
      throw new NotImplementedException();
    }

    private LanguagePreferences mPreferences;
    public override LanguagePreferences GetLanguagePreferences() {
      if (mPreferences == null) {
        mPreferences = new LanguagePreferences(Site, typeof(XSharpLanguageService).GUID, Name);
        mPreferences.Init();
      }
      return mPreferences;
    }

    private Scanner mScanner;
    public override IScanner GetScanner(IVsTextLines buffer) {
      throw new NotImplementedException();
    }

    public override string Name {
      get { return "XSharp"; }
    }

    public override AuthoringScope ParseSource(ParseRequest req) {
      return new Parser();
    }
  }
}