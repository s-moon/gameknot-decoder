﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameKnotDecoder
{
    public static class PGNUtils
    {
        private const string TagBracketLeft = "[";
        private const string TagBracketRight = "]";

        public static string ExtractPGNFromScript(string script)
        {
            string pgn;

            pgn = ExportSTR() + 
                "\n" + 
                ExportPGN(script);
            return pgn;
        }

        public static string ExportSTR()
        {
            return ExportEvent("") + "\n" +
                   ExportSite("") + "\n" +
                   ExportDate("") + "\n" +
                   ExportRound("") + "\n" +
                   ExportWhite("") + "\n" +
                   ExportBlack("") + "\n" +
                   ExportResult("") + "\n";
        }

        public static string ExportEvent(string evnt)
        {
            return TagBracketLeft + "Event \"Unknown\"" + TagBracketRight;
        }

        public static string ExportSite(string evnt)
        {
            return TagBracketLeft + "Site \"Unknown\"" + TagBracketRight;
        }

        public static string ExportDate(string evnt)
        {
            return TagBracketLeft + "Date \"Unknown\"" + TagBracketRight;
        }

        public static string ExportRound(string evnt)
        {
            return TagBracketLeft + "Round \"Unknown\"" + TagBracketRight;
        }

        public static string ExportWhite(string evnt)
        {
            return TagBracketLeft + "White \"Unknown\"" + TagBracketRight;
        }

        public static string ExportBlack(string evnt)
        {
            return TagBracketLeft + "Black \"Unknown\"" + TagBracketRight;
        }

        public static string ExportResult(string evnt)
        {
            return TagBracketLeft + "Result \"Unknown\"" + TagBracketRight;
        }

        public static string ExportPGN(string script)
        {
            string moves = ExtractMoves(script);
            return moves;
        }

        private static string ExtractMoves(string script)
        {
            int startPos = script.IndexOf("o.im('");
            int endPos = script.IndexOf("o.il");

            if (startPos == -1 || endPos == -1)
                return string.Empty;

            string moves = "";
            for (int i = startPos + 6; i < endPos - 5; i++)
            {
                if (char.IsUpper(script[i]) || char.IsLower(script[i]) || char.IsDigit(script[i]))
                {
                    moves += script[i];
                }
            }

            return moves;
        }
    }
}
