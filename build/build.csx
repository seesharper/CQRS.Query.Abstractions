#load "nuget:Dotnet.Build, 0.9.0"
#load "nuget:dotnet-steps, 0.0.2"

[StepDescription("Creates the NuGet packages")]
Step pack = () =>
{
    DotNet.Pack();
};

[DefaultStep]
[StepDescription("Deploys packages if we are on a tag commit in a secure environment.")]
AsyncStep deploy = async () =>
{
    pack();
    await Artifacts.Deploy();
};

await StepRunner.Execute(Args);
return 0;

