
using DotNetNuke.Services.Exceptions;
using System;
using Accuraty.SkinObjects.Agency.Components;

namespace Accuraty.SkinObjects.Agency
{
    public partial class View : AgencyModuleBase
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
               // do something
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

    }
}