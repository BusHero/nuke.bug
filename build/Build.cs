using Nuke.Common;
using Nuke.Common.CI.GitHubActions;
using Nuke.Common.Tools.GitVersion;
using Serilog;

[GitHubActions(
	"continous",
	GitHubActionsImage.UbuntuLatest,
	On = new[] { GitHubActionsTrigger.Push, GitHubActionsTrigger.WorkflowDispatch },
	InvokedTargets = new[] { nameof(Print) }
)]
class Build : NukeBuild
{
	public static int Main() => Execute<Build>(x => x.Print);

	[GitVersion]
	readonly GitVersion GitVersion;

	Target Print => _ => _
		.Executes(() => Log.Information($"GitVersion = {GitVersion.MajorMinorPatch}"));
}
