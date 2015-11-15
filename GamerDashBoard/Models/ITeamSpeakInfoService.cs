using GamerDashBoard.Models.TeamSpeak;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GamerDashBoard.Models
{
    public interface ITeamSpeakInfoService
    {
        TeamSpeakInfo getTeamSpeakInfo();
    }
}
