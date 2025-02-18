# AccuLadder v1.0.9+
This is the basic reference for Accuraty's common library of tools, utilities, and doohickies for DNN+2sxc projects. 
This replaces AccuKit so far and will also replace RazorKit, AccuKit11, and other libraries that are used in 
Accuraty's DNN+2sxc projects (usually in the /App_Code folder). 

## Quick Start Notes:

### Installation
Install the latest release from the project's [GitHub Release](https://github.com/jeremy-farrance/AccuratySolutions-2023/releases) page in the usual DNN way.
> [!CAUTION]
> This applies to Accuraty projects only. Intallation on projects with old libraries in the /App_Code folder require some additional steps; 
this was expected, see JRF. More on this <mark>below</mark>.

### Upgrade
Install a newer version, its a normal DNN extension install, it will just upgrade the existing version.

## Alpha and Experimental
This project is at the "alpha and experimental" stage of development. However, for internal Accuraty use, 
any release marked `Latest` is good for production use. It is not recommended for use in any project 
that is not under active development by a developer (e.g. prolly only JRF) who is familiar with the 
code and is able to immediately fix any issues that may arise.

## How to Use
Once AccuLadder is installed, you can use it in your C# code like this

### .cs files
```csharp
using Accuraty.Libraries.AccuLadder;

string phoneNumber = Accu.Text.FormatPhone("914.555.1212");
// result: (914) 555-1212
```

### .cshtml files (2sxc Views or RazorHost)
```csharp
@using Accuraty.Libraries.AccuLadder

@{
  string urlSlug = Accu.Web.ToSlug("** Special ** Board Meeting -- Nov 2022);
  // result: special-board-meeting-nov-2022
}
```

### .ascx files (Theme files and user controls)
```csharp
<%@ Import Namespace="Accuraty.Libraries.AccuLadder" %>

  <p class="small mt-2 mb-0"
    title="Current User is Super: <%=Accu.Dnn.IsSuper() %>"
  >
```

<hr>

## AccuKit Notes
<mark>AccuKit (in the /App_Code folder) is no longer needed.</mark> 
AccuLadder replaces it. To make the transition easy, compatability was added to AccuLadder to support 
the old namespace (AccuKit.) and classes. This means that you can and should install AccuLadder, but 
you need to:
1. Delete `/App_Code/AccuKit.cshtml`
2. Search through the project and find all occurrence of `AccuKit.`
3. At the top each page where it was used, add a `using` statement for `Accuraty.Libraries.AccuLadder` (see examples above)
4. No other changes should be necessary, see JRF is issues arise

### What about RazorKit, AccuKit11, and others?
No conflict so far, but in the future, when "replacement compatibility" is added to AccuLadder, the same process 
(as AccuKit above) will apply.

## Roadmap Possibilites and Ideas
- [ ] How did we lose .IsUrlSpecial() and what is the new method name?
- [ ] Add more documentation
- [ ] Add replacement compatibility for RazorKit, AccuKit11, and others
- [ ] How do we handle /App_Code/AccuTheme.cshtml in the AccuTheme* projects?
- [ ] Add AccuComponents.Buttons (or move forward on Stencil web components version of AccuComponents)?
- [ ] .Dev.Log(); add non-ephemeral logging to [files, database, other]? (or use 2sxc logging? or something else (Serilog?))?
- [ ] .Dnn.[roles]; helpers that work the way Accuraty does
  - [ ] see IsSM() in BEACN2023; one-offs that define a permission grouping
  - [ ] new .IsInRoles() that work for lists of RoleId or RoleNames
  - [ ] above need to support both && and || logic (all or any)
  - [ ] .GetRoleNameById() and .GetRoleIdByName()
- [ ] modernize the project as compositional interfaces, IAccuWeb, IAccuText, etc.?
- [ ] setup so using AccuLadder can be done via Dependency Injection
- [ ] setup so using AccuLadder can be done using NuGet
- [ ] Can we implement a terser syntax w/o adding (maintenance) complexity?
- [ ] Are we really a billion years away from plant/animal semiosis?

## Links to self-docs in the project
- [README.md](https://github.com/jeremy-farrance/AccuratySolutions-2023/blob/main/Libraries/AccuLadder/README.md)
- [Release Notes](https://github.com/jeremy-farrance/AccuratySolutions-2023/blob/main/Libraries/AccuLadder/releasenotes.txt)
- more?

## Accuraty Solutions
- [Accuraty](https://accuraty.com)
- [ACCU4](https://accu4.com) - Accuraty's DNN+2sxc reminders, learnings, and related stuff
- [GitHub/Accuraty](https://github.com/Accuraty)
