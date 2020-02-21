﻿#region license
// Copyright (C) 2020 ClassicUO Development Community on Github
// 
// This project is an alternative client for the game Ultima Online.
// The goal of this is to develop a lightweight client considering
// new technologies.
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <https://www.gnu.org/licenses/>.
#endregion

using System;

using ClassicUO.Game.UI.Controls;
using ClassicUO.IO.Resources;

using SDL2;

namespace ClassicUO.Game.UI.Gumps.Login
{
    [Flags]
    enum LoginButtons
    {
        None = 1,
        OK = 2,
        Cancel = 4
    }

    class LoadingGump : Gump
    {  

        private readonly Action<int> _buttonClick;
        internal readonly Label _Label;

        public LoadingGump(string labelText, LoginButtons showButtons, Action<int> buttonClick = null) : base(0, 0)
        {
            _buttonClick = buttonClick;
            CanCloseWithRightClick = false;
            CanCloseWithEsc = false;

            _Label = new Label(labelText, true, 1, 326, 2, align: TEXT_ALIGN_TYPE.TS_CENTER)
            {
                X = 162,
                Y = 178
            };

            Add(new ResizePic(0x0A28)
            {
                X = 142, Y = 134, Width = 366, Height = 212
            });

            Add(_Label);

            if (showButtons == LoginButtons.OK)
            {
                Add(new Button((int) LoginButtons.OK, 0x0481, 0x0483, 0x0482)
                {
                    X = 306, Y = 304, ButtonAction = ButtonAction.Activate
                });
            }
            else if (showButtons == LoginButtons.Cancel)
            {
                Add(new Button((int)LoginButtons.Cancel, 0x047E, 0x0480, 0x047F)
                {
                    X = 306,
                    Y = 304,
                    ButtonAction = ButtonAction.Activate
                });
            }
            else if (showButtons == (LoginButtons.OK | LoginButtons.Cancel))
            {
                Add(new Button((int) LoginButtons.OK, 0x0481, 0x0483, 0x0482)
                {
                    X = 264, Y = 304, ButtonAction = ButtonAction.Activate
                });

                Add(new Button((int) LoginButtons.Cancel, 0x047E, 0x0480, 0x047F)
                {
                    X = 348, Y = 304, ButtonAction = ButtonAction.Activate
                });
            }

        }



        protected override void OnKeyDown(SDL.SDL_Keycode key, SDL.SDL_Keymod mod)
        {
            if (key == SDL.SDL_Keycode.SDLK_KP_ENTER || key == SDL.SDL_Keycode.SDLK_RETURN)
                OnButtonClick((int) LoginButtons.OK);
        }


        public override void OnButtonClick(int buttonID)
        {
            _buttonClick?.Invoke(buttonID);
            base.OnButtonClick(buttonID);
        }
    }
}