using DotNetNuke.UI.Skins; 

namespace Accuraty.SkinObjects.Agency.Components
{
    public class AgencyModuleBase : SkinObjectBase 
	{
        public string ControlPath 
		{
            get 
			{
                return string.Concat(TemplateSourceDirectory, "/"); 
            }
        }
    }
}