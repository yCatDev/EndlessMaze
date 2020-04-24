using AbstractEngine.Core.Base;

namespace EndlessMazeGame.Entities
{
    public class MenuPoint: Entity
    {
        private Point _menuPlay, _menuContinue, _menuExit;
        private int _index = 0;
        public MenuPoint(string name, Point startPos, string resourceName, Area area) : base(name, startPos, resourceName, area)
        {
            
        }

        public void SetMenuPoints(Point play, Point @continue, Point exit)
        {
            _menuPlay = play;
            _menuContinue = @continue;
            _menuExit = exit;
        }
        
        public override void Update()
        {
            if (InputManger.OnKeyDown(VirtualKeys.Down))
            {
                if (_index < 2)
                    _index++;
                else
                {
                    return;
                }

                switch (_index)
                {
                    case 0:
                        SetPosition(_menuPlay);
                        break;
                    case 1:
                        SetPosition(_menuContinue);
                        break;
                    case 2:
                        SetPosition(_menuExit);
                        break;
                }
            }
            if (InputManger.OnKeyDown(VirtualKeys.Up))
            {
                if (_index > 0)
                    _index--;
                else
                {
                    return;
                }

                switch (_index)
                {
                    case 0:
                        SetPosition(_menuPlay);
                        break;
                    case 1:
                        SetPosition(_menuContinue);
                        break;
                    case 2:
                        SetPosition(_menuExit);
                        break;
                }
            }
        }
    }
}