using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public interface IPlayer
    {
        public void MoveLeft();
        public void MoveRight();
        public void Jump();
        public void Slide();
    }
}
