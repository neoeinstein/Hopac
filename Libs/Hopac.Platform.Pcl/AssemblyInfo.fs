namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("Hopac.Platform.PCL")>]
[<assembly: AssemblyProductAttribute("Hopac.Platform.PCL")>]
[<assembly: AssemblyDescriptionAttribute("A library for Higher-Order, Parallel, Asynchronous and Concurrent programming in F#.")>]
[<assembly: AssemblyVersionAttribute("0.1.3")>]
[<assembly: AssemblyFileVersionAttribute("0.1.3")>]
[<assembly: AssemblyCompanyAttribute("Housemarque Inc.")>]
[<assembly: AssemblyCopyrightAttribute("� Housemarque Inc.")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "0.1.3"
