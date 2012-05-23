/////////////////////////////////////////////////////////////////////////*
//Ink Studios Source File.
//Copyright (C), Ink Studios, 2011.
//////////////////////////////////////////////////////////////////////////
// EntityManager interface
//////////////////////////////////////////////////////////////////////////
// 21/12/2011 : Created by Filip 'i59' Lundgren
////////////////////////////////////////////////////////////////////////*/
#ifndef __I_MONO_ENTITY_MANAGER_H__
#define __I_MONO_ENTITY_MANAGER_H__

/// <summary>
/// The entity manager is used to register and handle Mono-registered entities.
/// </summary>
struct IMonoEntityManager
{
	/// <summary>
	/// Retrieve the script of an entity, returns NULL if script could not be located.
	/// </summary>
	virtual IMonoClass *GetScript(EntityId entityId, bool returnBackIfInvalid = false) = 0;
};

#endif //__I_MONO_ENTITY_MANAGER_H__