// include Fake lib
#r "packages/FAKE/tools/FakeLib.dll"
open Fake
open Fake.Paket
open Fake.Testing

Restore (fun p -> p)

// Properties
let buildDir = "./bin/app"
let testDir = "./bin/test"

// Targets
Target "Clean" (fun _ ->
    CleanDir buildDir
)

Target "BuildApp" (fun _ ->
    !! "src/app/**/*.fsproj"
    |> MSBuildDebug buildDir "Build"
    |> Log "AppBuild-Output: "
)

Target "BuildTest" (fun _ ->
    !! "src/test/**/*.fsproj"
    |> MSBuildDebug testDir "Build"
    |> Log "TestBuild-Output: "
)

Target "RunTest" (fun _ ->
    !! (testDir @@ "*.Tests.dll")
    |> xUnit2 (fun p -> { p with HtmlOutputPath = Some (testDir @@ "TestResults.html") })
)

Target "Default" (fun _ ->
    trace "building..."
)

// Dependencies
"Clean"
  ==> "BuildApp"
  ==> "BuildTest"
  ==> "RunTest"
  ==> "Default"

// start build
RunTargetOrDefault "Default"
