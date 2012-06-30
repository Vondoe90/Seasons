/////////////////////////////////////////////////////////////////////////*
//Ink Studios Source File.
//Copyright (C), Ink Studios, 2011.
//////////////////////////////////////////////////////////////////////////
// IMonoAssembly interface for external projects, i.e. CryGame.
//////////////////////////////////////////////////////////////////////////
// 18/12/2011 : Created by Filip 'i59' Lundgren
////////////////////////////////////////////////////////////////////////*/
#ifndef __I_MONO_ASSEMBLY__
#define __I_MONO_ASSEMBLY__

struct IMonoClass;

/// <summary>
/// Reference to a Mono assembly; used to for example instantiate classes contained within a C# dll.
/// </summary>
struct IMonoAssembly
{
public:
	/// <summary>
	/// Deletes the assembly and cleans up used objects.
	/// </summary>
	virtual void Release() = 0;

	/// <summary>
	/// Gets a custom C# class from within the assembly.
	/// Note: This does not construct an new instance of the class, only returns an uninitialized IMonoScript. To instantiate a class, see IMonoAssembly::InstantiateClass
	/// </summary>
	/// <example>
	/// IMonoScript *pClass = gEnv->pMonoScriptSystem->GetCryBraryAssembly()->GetCustomClass("Vec3");
	/// </example>
	virtual IMonoClass *GetClass(const char *className, const char *nameSpace = "CryEngine") = 0;
};

#endif //__I_MONO_ASSEMBLY__`	