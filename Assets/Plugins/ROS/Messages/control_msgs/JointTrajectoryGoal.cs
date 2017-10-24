using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using uint8 = System.Byte;
using Messages.geometry_msgs;
using Messages.sensor_msgs;
using Messages.actionlib_msgs;

using Messages.std_msgs;
using String=System.String;

namespace Messages.control_msgs
{
#if !TRACE
    [System.Diagnostics.DebuggerStepThrough]
#endif
    public class JointTrajectoryGoal : IRosMessage
    {

			public Messages.trajectory_msgs.JointTrajectory trajectory; //woo


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public override string MD5Sum() { return "2a0eff76c870e8595636c2a562ca298e"; }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool HasHeader() { return false; }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool IsMetaType() { return true; }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public override string MessageDefinition() { return @"trajectory_msgs/JointTrajectory trajectory"; }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public override MsgTypes msgtype() { return MsgTypes.control_msgs__JointTrajectoryGoal; }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool IsServiceComponent() { return false; }

        [System.Diagnostics.DebuggerStepThrough]
        public JointTrajectoryGoal()
        {
            
        }

        [System.Diagnostics.DebuggerStepThrough]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public JointTrajectoryGoal(byte[] SERIALIZEDSTUFF)
        {
            Deserialize(SERIALIZEDSTUFF);
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public JointTrajectoryGoal(byte[] SERIALIZEDSTUFF, ref int currentIndex)
        {
            Deserialize(SERIALIZEDSTUFF, ref currentIndex);
        }



        [System.Diagnostics.DebuggerStepThrough]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public override void Deserialize(byte[] SERIALIZEDSTUFF, ref int currentIndex)
        {
            int arraylength=-1;
            bool hasmetacomponents = false;
            object __thing;
            int piecesize=0;
            byte[] thischunk, scratch1, scratch2;
            IntPtr h;
            
            //trajectory
            trajectory = new Messages.trajectory_msgs.JointTrajectory(SERIALIZEDSTUFF, ref currentIndex);
        }

        [System.Diagnostics.DebuggerStepThrough]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public override byte[] Serialize(bool partofsomethingelse)
        {
            int currentIndex=0, length=0;
            bool hasmetacomponents = false;
            byte[] thischunk, scratch1, scratch2;
            List<byte[]> pieces = new List<byte[]>();
            GCHandle h;
            
            //trajectory
            if (trajectory == null)
                trajectory = new Messages.trajectory_msgs.JointTrajectory();
            pieces.Add(trajectory.Serialize(true));
            //combine every array in pieces into one array and return it
            int __a_b__f = pieces.Sum((__a_b__c)=>__a_b__c.Length);
            int __a_b__e=0;
            byte[] __a_b__d = new byte[__a_b__f];
            foreach(var __p__ in pieces)
            {
                Array.Copy(__p__,0,__a_b__d,__a_b__e,__p__.Length);
                __a_b__e += __p__.Length;
            }
            return __a_b__d;
        }

        public override void Randomize()
        {
            int arraylength=-1;
            Random rand = new Random();
            int strlength;
            byte[] strbuf, myByte;
            
            //trajectory
            trajectory = new Messages.trajectory_msgs.JointTrajectory();
            trajectory.Randomize();
        }

        public override bool Equals(IRosMessage ____other)
        {
            if (____other == null) return false;
            bool ret = true;
            control_msgs.JointTrajectoryGoal other = (Messages.control_msgs.JointTrajectoryGoal)____other;

            ret &= trajectory.Equals(other.trajectory);
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
