using CryEngine;

namespace CryGameCode
{
	[FlowNode(Name = "Material", UICategory = "MaterialGraph")]
	public class MaterialNode : FlowNode
	{
		[Port(Name = "Material", Type = PortType.Material)]
		public void MaterialName(string name) { }

		[Port(Description = "Gets the material")]
		public void Get()
		{
			var material = Material.Find(GetPortString(MaterialName));
			if(material == null)
				return;

			var subMatId = GetPortInt(Submaterial);
			if(subMatId != -1)
			{
				material = material.GetSubmaterial(GetPortInt(Submaterial));
				if(material == null)
					return;
			}

			AlphaTestOutput.Activate(material.AlphaTest);
			OpacityOutput.Activate(material.Opacity);
			GlowOutput.Activate(material.Glow);
			ShininessOutput.Activate(material.Shininess);

			DiffuseColorOutput.Activate(material.DiffuseColor);
			EmissiveColorOutput.Activate(material.EmissiveColor);
			SpecularColorOutput.Activate(material.SpecularColor);
		}

		[Port(Description = "Sets the entity's material")]
		public void Set()
		{
			var material = Material.Find(GetPortString(MaterialName));

			if(material == null)
				return;

			var subMatId = GetPortInt(Submaterial);

			if(subMatId != -1)
			{
				material = material.GetSubmaterial(subMatId);

				if(material == null)
					return;
			}

			if(IsVec3PortActive(DiffuseColor))
				material.DiffuseColor = GetPortVec3(DiffuseColor);

			if(IsVec3PortActive(EmissiveColor))
				material.EmissiveColor = GetPortVec3(EmissiveColor);

			if(IsVec3PortActive(SpecularColor))
				material.SpecularColor = GetPortVec3(SpecularColor);

			if(IsFloatPortActive(AlphaTest))
				material.AlphaTest = GetPortFloat(AlphaTest);

			if(IsFloatPortActive(Opacity))
				material.Opacity = GetPortFloat(Opacity);

			if(IsFloatPortActive(Glow))
				material.Glow = GetPortFloat(Glow);

			if(IsFloatPortActive(Shininess))
				material.Shininess = GetPortFloat(Shininess);
		}

		[Port(Description = "If not -1, attempts to get a submaterial at the specified slot")]
		public void Submaterial(int value = -1) { }

		[Port]
		public void AlphaTest(float value) { }

		[Port(Name = "Alpha Test")]
		public OutputPort<float> AlphaTestOutput { get; set; }

		[Port]
		public void Opacity(float value) { }

		[Port(Name = "Opacity")]
		public OutputPort<float> OpacityOutput { get; set; }

		[Port]
		public void Glow(float value) { }

		[Port(Name = "Glow")]
		public OutputPort<float> GlowOutput { get; set; }

		[Port]
		public void Shininess(float value) { }

		[Port(Name = "Shininess")]
		public OutputPort<float> ShininessOutput { get; set; }

		[Port]
		public void DiffuseColor(Vec3 value) { }

		[Port(Name = "DiffuseColor")]
		public OutputPort<Vec3> DiffuseColorOutput { get; set; }

		[Port]
		public void EmissiveColor(Vec3 value) { }

		[Port(Name = "EmissiveColor")]
		public OutputPort<Vec3> EmissiveColorOutput { get; set; }

		[Port]
		public void SpecularColor(Vec3 value) { }

		[Port(Name = "SpecularColor")]
		public OutputPort<Vec3> SpecularColorOutput { get; set; }
	}
}