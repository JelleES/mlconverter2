﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace mlconverter2.bkgr
{
    class SoundfontBKGR
    {
        // ---- data arrays ----

        int[] instrumentPointers;
        int[] samplePointers;

        int[][] instrumentDef;
        int[][] sampleDef;

        // ---- variables ----

        int activeSample;

        // ---- properties ----

        public int ActiveSample
        {
            get { return activeSample; }
            set { activeSample = value; }
        }

        public int[] Sample
        {
            get { return sampleDef[activeSample]; }
        }

        // ---- functions ----

        public void prepairSoundfont(BinaryReader file)
        {
            file.BaseStream.Position = 0x006ADE44;
            instrumentPointers = new int[0x32];
            for (int i = 0; i < 0x32; i++) instrumentPointers[i] = Common.repairPointer(file.ReadInt32());

            file.BaseStream.Position = 0x006ADF0C;
            samplePointers = new int[0x91];
            for (int i = 0; i < 0x91; i++) samplePointers[i] = Common.repairPointer(file.ReadInt32());

            instrumentDef = new int[0x32][];

            for (int i = 0; i < 0x32; i++ )
            {
                instrumentDef[i] = new int[0x44 / 4];
                file.BaseStream.Position = instrumentPointers[i];

                for (int j = 0; j < 0x44 / 4; j++) instrumentDef[i][j] = file.ReadInt32();
            }

            sampleDef = new int[0x91][];

            for (int i = 0; i < 0x91; i++)
            {
                sampleDef[i] = new int[0x44 / 4];
                file.BaseStream.Position = samplePointers[i];
                
                for (int j = 0; j < 0x44 / 4; j++) sampleDef[i][j] = file.ReadInt32();
            }

            file.Close();
        }

        public void sampleToWave(BinaryReader gba, BinaryWriter file)
        {
            int sampleLength = sampleDef[activeSample][6] - sampleDef[activeSample][4];
            gba.BaseStream.Position = Common.repairPointer(sampleDef[activeSample][4]);
            byte[] sample = gba.ReadBytes(sampleLength);

            file.Write(new byte[] { 0x52, 0x49, 0x46, 0x46 });
            file.Write(sampleLength + 0x24);
            file.Write(new byte[] { 0x57, 0x41, 0x56, 0x45, 0x66, 0x6D, 0x74, 0x20, 0x10, 0x00, 0x00, 0x00, 0x01, 0x00, 0x01, 0x00 });
            file.Write(sampleDef[activeSample][2]);
            file.Write(sampleDef[activeSample][2]);
            file.Write(new byte[] { 0x01, 0x00, 0x08, 0x00, 0x64, 0x61, 0x74, 0x61 });
            file.Write(sampleLength);

            for (int i = 0; i < sample.Length; i++) file.Write(Convert.ToSByte(sample[i] - 0x80));

            gba.Close();
            file.Close();
        }
    }
}
