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
using System.Globalization;
using System.Runtime.CompilerServices;

namespace ClassicUO.Game
{
    static class SerialHelper
    {
        [MethodImpl(256)]
        public static bool IsValid(uint serial) => serial > 0 && serial < 0x80000000;

        [MethodImpl(256)]
        public static bool IsMobile(uint serial) => serial > 0 && serial < 0x40000000;

        [MethodImpl(256)]
        public static bool IsItem(uint serial) => serial >= 0x40000000 && serial < 0x80000000;

        [MethodImpl(256)]
        public static bool IsValidLocalGumpSerial(uint serial) => serial >= Constants.JOURNAL_LOCALSERIAL && serial < 0xFFFF_FFFF;

        public static uint Parse(string str)
        {
            if (str.StartsWith("0x"))
                return uint.Parse(str.Remove(0, 2), NumberStyles.HexNumber);

            if (str.Length > 1 && str[0] == '-')
                return (uint) int.Parse(str);

            return uint.Parse(str);
        }
    }
}