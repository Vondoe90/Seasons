/////////////////////////////////////////////////////////////////////////*
//Ink Studios Source File.
//Copyright (C), Ink Studios, 2011.
//////////////////////////////////////////////////////////////////////////
// Used to easily get any type of value from C++ to C#,
// also used to serialize C# objects for RMI's.
//////////////////////////////////////////////////////////////////////////
// 31/12/2011 : Created by Filip 'i59' Lundgren
////////////////////////////////////////////////////////////////////////*/
#ifndef __MONO_ANY_VALUE__
#define __MONO_ANY_VALUE__

/// <summary>
/// Used within MonoAnyValue and IMonoObject to easily get the object type contained within.
/// </summary>
enum EMonoAnyType
{
	eMonoAnyType_Unknown = -1,

	eMonoAnyType_Boolean,

	eMonoAnyType_Integer,
	eMonoAnyType_UnsignedInteger,
	eMonoAnyType_Short,
	eMonoAnyType_UnsignedShort,
	eMonoAnyType_Float,
	eMonoAnyType_Vec3,

	eMonoAnyType_String,
	eMonoAnyType_Array,
	eMonoAnyType_Class,
	eMonoAnyType_Assembly,
	eMonoAnyType_IntPtr,

	eMonoAnyType_Last
};

/// <summary>
/// Simple class used to easily convert common C++ types to their C# equivalents.
/// </summary>
struct MonoAnyValue
{
	MonoAnyValue() : type(eMonoAnyType_Unknown) { };
	MonoAnyValue(bool value) : type(eMonoAnyType_Boolean) { b = value; }
	MonoAnyValue(int value) : type(eMonoAnyType_Integer) { i = value; }
	MonoAnyValue(unsigned int value) : type(eMonoAnyType_UnsignedInteger) { u = value; }
	MonoAnyValue(short value) : type(eMonoAnyType_Short) { i = value; }
	MonoAnyValue(unsigned short value) : type(eMonoAnyType_UnsignedShort) { u = value; }
	MonoAnyValue(float value) : type(eMonoAnyType_Float) { f = value; }
	MonoAnyValue(const char *value) : type(eMonoAnyType_String) { str = value; }
	MonoAnyValue(string value) : type(eMonoAnyType_String) { str = value.c_str(); }
	MonoAnyValue(Vec3 value) : type(eMonoAnyType_Vec3) { vec3.x = value.x; vec3.y = value.y; vec3.z = value.z; }
	MonoAnyValue(Ang3 value) : type(eMonoAnyType_Vec3) { vec3.x = value.x; vec3.y = value.y; vec3.z = value.z; }

	void *GetValue()
	{
		switch(type)
		{
		case eMonoAnyType_Boolean:
			return &b;
		case eMonoAnyType_UnsignedInteger:
		case eMonoAnyType_UnsignedShort:
			return &u;
		case eMonoAnyType_Integer:
		case eMonoAnyType_Short:
			return &i;
		case eMonoAnyType_Float:
			return &f;
		case eMonoAnyType_Vec3:
			return Vec3(vec3.x, vec3.y, vec3.z);
		case eMonoAnyType_String:
			return &str;
		}
	}

	EMonoAnyType type;
	union
	{
		bool			b;
		float			f;
		int				i;
		unsigned int	u;
		const char*		str;
		struct { float x,y,z; } vec3;
	};
};

#endif //__MONO_ANY_VALUE__