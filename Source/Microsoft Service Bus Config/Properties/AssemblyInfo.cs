using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Microsoft Service Bus Config")]
[assembly: AssemblyDescription("Provides configuration utilities for Microsoft Service Bus namespaces.")]

#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Release")]
#endif
[assembly: AssemblyCompany("PyPup Software")]
[assembly: AssemblyProduct("PyPup Infrastructure")]
[assembly: AssemblyCopyright("Copyright © 2013")]

[assembly: NeutralResourcesLanguageAttribute("en-GB")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("2fa16886-9a54-4137-adc1-f30309ad441a")]

// Assembly Version is updated manually to provide .NET compatibility between release versions.
// The Major and Minor values are updated to keep in-line with the Assembly Informational Version.
[assembly: AssemblyVersion("1.0.0.0")]

// Assembly File Version is updated automatically by the build process.
// The Major and Minor values are kept in-line with the Assembly Informational Version.
// The Build and Revision values are assigned by the build process.
[assembly: AssemblyFileVersion("1.0.0.0")]

// Assembly Information Version is updated according to Semantic Versioning rules: http://semver.org/ 
// The value is assigned by the build process.
// This is the version number used when publishing a NuGet package for the assembly.
[assembly: AssemblyInformationalVersion("1.0.0-Dev")]
