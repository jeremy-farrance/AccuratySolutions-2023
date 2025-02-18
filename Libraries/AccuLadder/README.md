# AccuLadder

## How to Generate the Docs (DocFX)

If DocFX is not installed, install it using dotnet: `dotnet tool install -g docfx`

PowerShell or command line to C:\dev\gen\docfx
Then, run the following command: `docfx build docfx.json [--serve]`
Then, browse to http://localhost:8080/

It builds into `C:\dev\gh.io\jeremy-farrance\AccuLadder` which is git remote for 
https://github.com/jeremy-farrance/jeremy-farrance.github.io

To publish, open the VS Code project and publish main directly to the remote repo.

Key files:
- docfx.json
- templates/modern/
  - layout/_master.tmpl
  - public/main.css 
  - others?
 
TODO: Automate all the above on Release builds

## Helpers - Draft and Changing Outline as we convert...

This is a collection of helper classes and methods that we use at Accuraty. It is a work in progress. 
The main goal is to have a set of tools that makes the way we do things at Accuraty easier and more 
consistent. This utility is geared towards DNN projects since initially it is built to install in
DNN as a Library. However, it should be possible to use it in any .NET project.

Needs to straighten out concepts like Polymorphism, IsDebug vs IsDemo vs IsTesting, etc. This means 
we need to have a clear idea of how we use these and the best way to use them. For example, we think 
polymorphism is a good idea, but we have not used it much (or effectively).

Seems like the defaults should be debug and demo on and then changing the config 
at go-live to turn them off?

- Accu.Version

- Accu.Dev
  - x .Debug(get/set non-static)
  - x .Log(string)
  - x .Log(name, value)
  
- Accu.Dnn
  - .IsHome() - from AccuKit11
  - x .IsSuper() - from AccuKit11
  - x .IsAdminOrSuper() - from AccuKit11 (.isAdminOrHost)
  - [ matchCM and matchSM, IsCM, IsContentManager, etc ] - from AccuKit11
  - x .GetUser() - from AccuKit11
  - .IsInRoleName() - from AccuKit11

- Accu.Theme // what about the cool IconHelp(s) in the Accuraty version of Upendo User Manager? 
  - .IsHome() - from AccuKit11; map to Dnn.IsHome
  - .Path() - from AccuKit11.ThemePath() (.SkinPath)
  - .CssPath() - from AccuKit11. or AccuTheme ? (/dist ?)
  - .JsPath() - should /dist or /public be the default?
  - .ImagePath() - from AccuKit11 or AccuTheme ? (/dist/media/images)
  - .MediaPath() - ?
  - .SvgPath() - ?
  - .AccuIcon() - from early AccuKit or AccuTheme?
  - .BootstrapIcon() - from early AccuKit or
  - .FontAwesomeIcon() - future idea?
  - .FileExists() - from AccuTheme; .SkinFileExists()

- Accu.Sxc // Nothing here at all yet? Hmm...

- Accu.Text
  - .ToSlug() - .ToSlug from AccuKit, from AccuKit11
  - .FormatPhone() - .FormatPhone from AccuKit, AccuKit11, others?

- Accu.Utils (better name? .Misc)
  - .IsAccuratyIP()... see __debug.ascx in ASL-ACCU4
  - .GetUrlParam() - was urlQSParam() from AccuKit11
  - .IsUrlSpecial()
  - .GetIpAddress() - from AccuKit11
  - .GetIpFromHostname() - from AccuKit11
  
- Accu.Nx
  - x .Sbe() - sbe() from AccuKit
  - .sbeRule() - needs rethink, rename, etc
  - .Poly() - from AccuKit11

- Accu.[others] (.Misc?)
  - .GetWidthFromImageFile() - from AccuKit imageGetWidthfromFile(), AccuKit11
  - .GetHeightFromImageFile() - from AccuKit imageGetHeightfromFile(), AccuKit11
  - .GetImageDimensionsFromFile() - new, should return JSON or a Dictionary or an Array or a Tuple??
  - .GetVersion() - from AccuKit11
  - 

- Accu.Version()
- Accu.[other]

- RazorKit
- AccuKit - done ~20231025
- AccuKit11
- AccuKit21
- AccuTheme
- AccuEvents - not actually in use anywhere?

### Roadmap

These are things we are definitely planning to do. Scroll down to see ideas, wishlist, etc.

Unofficially, so far, anything goes. But, in general, the idea is to have a set of tools that 
makes the way we do things at Accuraty easier and more consistent. Secondarily, it should 
stay focused on anything that helps any agency (Accuraty or otherwise) do their work better.

#### 1.1

- Drop in replacement for all previous App_Code/AccuKit*.cs* variations. Install this module 
and then manually delete the old (conflicting) files in App_Code. (Or, is it possible to have 
the installer detect and delete them

- AccuKit.cshtml is done/working as of v1.0.7

#### 1.2

- Enhanced logging (don't go too far, there are MANY other tools for that)
  - to DNN's log, to a file
  - performance logging using Stopwatch, TimeSpans, etc
  - Context logging (e.g. page, module, etc)
  - Usage Context? demo, debug, testing, reporting, etc
- TBD
- 

### Ideas, Wishlist, and other stuff

Reminder: include some context. Why is this needed? _What **problem** does it solve?_ What is the ...
  
### History

RazorKit started life in late 2018 (20181015 is the first version-date I can find (which project?)) 
and evolved through AccuKit (20200721) and then the misguided AccuKit11 and AccuKit21 later. 
After multiple false starts, in Aug 2023 started a rethink/rewrite in Visual Studio as a 
DNN installable Library using Upendo's generator as a starting point. 20230820-26 JRF

### License

So far the license is Apathy Public License. That simply means I do not care what you do 
with it. But if it breaks or deletes your stuff or in any way causes you harm or loss or 
whatever, I cannot be held liable. That having been said, without any research (yet), let 
us officially say the license is MIT + Apathy. 20230820 JRF
