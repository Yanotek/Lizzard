using RDPCOMAPILib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Core.Commands.RDP
{
    public class Remote
    {
        RemoteScreenCommand screenCommand;
        RDPSession session;

        public Remote(RemoteScreenCommand screenCommand)
        {
            this.screenCommand = screenCommand;
        }

        public string ConnectionString()
        {
            session = new RDPSession();
            session.Open();

            session.add_OnAttendeeConnected(OnAttendeeConnected);

            IRDPSRAPIInvitation invitation = session.Invitations.CreateInvitation(null, screenCommand.UserName, screenCommand.Password, 1);
            return invitation.ConnectionString;
        }

        private void OnAttendeeConnected(object pAttendee)
        {
            // TODO Make overridable
            var attendee = (IRDPSRAPIAttendee)pAttendee;
            attendee.ControlLevel = CTRL_LEVEL.CTRL_LEVEL_INTERACTIVE;
        }
    }
}
