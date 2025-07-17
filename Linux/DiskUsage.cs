// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

using System;
using System.Diagnostics;
using System.IO;

namespace WatchDog.Linux
{
    public static class DiskUsage
    {

        public static bool ShouldCheckDrive(DriveInfo driveInfo)
        {
            if (!driveInfo.IsReady)
            {
                return false;
            }

            // Skip not interesting Linux mount points.
            if (driveInfo.TotalSize == 0 ||
                string.Equals(driveInfo.DriveFormat, "squashfs", StringComparison.Ordinal) ||
                string.Equals(driveInfo.DriveFormat, "tmpfs", StringComparison.Ordinal) ||
                string.Equals(driveInfo.DriveFormat, "overlay", StringComparison.Ordinal) ||
                string.Equals(driveInfo.RootDirectory.FullName, "/boot/efi", StringComparison.Ordinal))
            {
                return false;
            }

            // CDRom and Network drives do not have Avg queue length perf counter
            if (driveInfo.DriveType == DriveType.CDRom || driveInfo.DriveType == DriveType.Network)
            {
                return false;
            }

            return true;
        }

        public static double GetTotalDiskSpace(string driveName, SizeUnit sizeUnit = SizeUnit.Bytes)
        {
            return GetTotalDiskSpace(new DriveInfo(driveName), sizeUnit);
        }

        public static double GetTotalDiskSpace(DriveInfo driveInfo, SizeUnit sizeUnit = SizeUnit.Bytes)
        {
            long total = driveInfo.TotalSize;
            return Math.Round(ConvertToSizeUnits(total, sizeUnit), 2);
        }

        public static float GetCurrentDiskSpaceUsedPercent(string driveName)
        {
            return GetCurrentDiskSpaceUsedPercent(new DriveInfo(driveName));
        }

        public static float GetCurrentDiskSpaceUsedPercent(DriveInfo driveInfo)
        {
            long availableMB = driveInfo.AvailableFreeSpace / 1024 / 1024;
            long totalMB = driveInfo.TotalSize / 1024 / 1024;
            double usedPct = ((double)(totalMB - availableMB)) / totalMB;

            return (float)(usedPct * 100f);
        }

        public static double GetAvailableDiskSpace(string driveName, SizeUnit sizeUnit = SizeUnit.Bytes)
        {
            var driveInfo = new DriveInfo(driveName);
            long available = driveInfo.AvailableFreeSpace;

            return Math.Round(ConvertToSizeUnits(available, sizeUnit), 2);
        }

        public static double GetUsedDiskSpace(string driveName, SizeUnit sizeUnit = SizeUnit.Bytes)
        {
            var driveInfo = new DriveInfo(driveName);
            long used = driveInfo.TotalSize - driveInfo.AvailableFreeSpace;

            return Math.Round(ConvertToSizeUnits(used, sizeUnit), 2);
        }

        private static double ConvertToSizeUnits(double amount, SizeUnit sizeUnit)
        {
            switch (sizeUnit)
            {
                case SizeUnit.Bytes:
                    return amount;

                case SizeUnit.Kilobytes:
                    return amount / 1024;

                case SizeUnit.Megabytes:
                    return amount / 1024 / 1024;

                case SizeUnit.Gigabytes:
                    return amount / 1024 / 1024 / 1024;

                case SizeUnit.Terabytes:
                    return amount / 1024 / 1024 / 1024 / 1024;

                default:
                    return amount;
            };
        }
    }

    public enum SizeUnit
    {
        Bytes,
        Kilobytes,
        Megabytes,
        Gigabytes,
        Terabytes,
    }
}
