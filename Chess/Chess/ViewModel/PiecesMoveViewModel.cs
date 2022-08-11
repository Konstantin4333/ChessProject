using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Chess.ViewModel
{
    public class PiecesMoveViewModel : BaseViewModel
    {
        private DelegateCommand move;
        private ICommand MoveKing{
            get
            {
                return  move ?? (move = new DelegateCommand(() =>
                {
                    MoveAction();
                }));
            }
        }
        public void MoveAction()
        {

        }

    }
}
