using System;
using SDL2;
using Timer = System.Timers.Timer;

namespace Zelda_3_Launcher
{
    public class MyController
    {
        private IntPtr controller;
        public bool connected = false;

        public MyController()
        {
            // Initialize SDL
            SDL.SDL_Init(SDL.SDL_INIT_GAMECONTROLLER);

            // Check if any joysticks are connected
            if (SDL.SDL_NumJoysticks() > 0)
            {
                // Open the first joystick
                controller = SDL.SDL_GameControllerOpen(0);
                connected = true;
            }
        }

        public string? GetButtonName()
        {
            SDL.SDL_PumpEvents();
            SDL.SDL_FlushEvents(SDL.SDL_EventType.SDL_FIRSTEVENT, SDL.SDL_EventType.SDL_LASTEVENT);

            var window = SDL.SDL_CreateWindow("Awaiting input...", Form.ActiveForm.Location.X + 292, Form.ActiveForm.Location.Y + 199, 150, 50,
                SDL.SDL_WindowFlags.SDL_WINDOW_INPUT_GRABBED |
                SDL.SDL_WindowFlags.SDL_WINDOW_BORDERLESS |
                SDL.SDL_WindowFlags.SDL_WINDOW_ALWAYS_ON_TOP);

            SDL.SDL_ShowCursor(SDL.SDL_DISABLE);

            var leftTrigger = false;
            var rightTrigger = false;
            var stop = DateTime.Now.AddSeconds(5);

            while (true)
            {
                SDL.SDL_Event e;

                // Wait for an event to occur
                SDL.SDL_PollEvent(out e);

                // Check for ESC key
                if (e.type == SDL.SDL_EventType.SDL_KEYDOWN)
                {
                    if (SDL.SDL_GetKeyName(e.key.keysym.sym) == "Escape")
                    {
                        SDL.SDL_DestroyWindow(window);
                        return null;
                    }
                }

                // Check for trigger axis event
                if (e.type == SDL.SDL_EventType.SDL_CONTROLLERAXISMOTION)
                {
                    if (e.caxis.axis == ((byte)SDL.SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_TRIGGERLEFT))
                    {
                        leftTrigger = true;
                    }
                    else if (e.caxis.axis == ((byte)SDL.SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_TRIGGERRIGHT))
                    {
                        rightTrigger = true;
                    }

                    if (e.caxis.axis == ((byte)SDL.SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_TRIGGERLEFT) && e.caxis.axisValue == 0 && leftTrigger)
                    {
                        SDL.SDL_DestroyWindow(window);
                        return "L2";
                    }
                    else if (e.caxis.axis == ((byte)SDL.SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_TRIGGERRIGHT) && e.caxis.axisValue == 0 && rightTrigger)
                    {
                        SDL.SDL_DestroyWindow(window);
                        return "R2";
                    }
                }

                // Check if the event was a controller button press
                if (e.type == SDL.SDL_EventType.SDL_CONTROLLERBUTTONDOWN)
                {
                    SDL.SDL_DestroyWindow(window);
                    return (ConvertButtonID(e.cbutton.button));
                }

                if (DateTime.Now >= stop)
                {
                    SDL.SDL_DestroyWindow(window);
                    return null;
                }
            }
        }

        internal static string? ConvertButtonID(byte button)
        {
            switch (button)
            {
                case 0:
                    return "A";
                case 1:
                    return "B";
                case 2:
                    return "X";
                case 3:
                    return "Y";
                case 4:
                    return "Back";
                case 5:
                    return "Guide";
                case 6:
                    return "Start";
                case 7:
                    return "L3";
                case 8:
                    return "R3";
                case 9:
                    return "Lb";
                case 10:
                    return "Rb";
                case 11:
                    return "DPadUp";
                case 12:
                    return "DPadDown";
                case 13:
                    return "DPadLeft";
                case 14:
                    return "DPadRight";
                default:
                    return null;
            }
        }

        public void Close()
        {
            // Close the joystick and quit SDL
            SDL.SDL_GameControllerClose(controller);
            SDL.SDL_Quit();
        }
    }

}
