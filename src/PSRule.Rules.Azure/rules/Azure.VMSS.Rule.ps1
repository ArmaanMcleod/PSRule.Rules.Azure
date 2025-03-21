# Copyright (c) Microsoft Corporation.
# Licensed under the MIT License.

#
# Validation rules for Azure Virtual Machine Scale Sets
#

#region Virtual machine scale set

# Synopsis: Use VM naming requirements
Rule 'Azure.VMSS.Name' -Ref 'AZR-000261' -Type 'Microsoft.Compute/virtualMachineScaleSets' -Tag @{ release = 'GA'; ruleSet = '2020_06' } {
    # https://docs.microsoft.com/en-us/azure/azure-resource-manager/management/resource-name-rules#microsoftcompute

    # Between 1 and 64 characters long
    $Assert.GreaterOrEqual($TargetObject, 'Name', 1)
    $Assert.LessOrEqual($TargetObject, 'Name', 64)

    # Alphanumerics, underscores, periods, and hyphens
    # Start with alphanumeric
    # End with alphanumeric or underscore
    Match 'Name' '^[A-Za-z0-9]((-|\.)*\w){0,79}$'
}

# Synopsis: Use VM naming requirements
Rule 'Azure.VMSS.ComputerName' -Ref 'AZR-000262' -Type 'Microsoft.Compute/virtualMachineScaleSets' -Tag @{ release = 'GA'; ruleSet = '2020_06' } {
    # https://docs.microsoft.com/en-us/azure/azure-resource-manager/management/resource-name-rules#microsoftcompute

    $maxLength = 64
    $matchExpression = '^[A-Za-z0-9]([A-Za-z0-9-.]){0,63}$'
    if (IsWindowsOS) {
        $maxLength = 15

        # Alphanumeric or hyphens
        # Can not include only numbers
        $matchExpression = '^[A-Za-z0-9-]{0,14}[A-Za-z-][A-Za-z0-9-]{0,14}$'
    }

    # Between 1 and 15/ 64 characters long
    $Assert.GreaterOrEqual($TargetObject, 'Properties.virtualMachineProfile.osProfile.computerNamePrefix', 1)
    $Assert.LessOrEqual($TargetObject, 'Properties.virtualMachineProfile.osProfile.computerNamePrefix', $maxLength)

    # Alphanumerics and hyphens
    # Start and end with alphanumeric
    Match 'Properties.virtualMachineProfile.osProfile.computerNamePrefix' $matchExpression
}

# Synopsis: Use SSH keys instead of common credentials to secure virtual machine scale sets against malicious activities.
Rule 'Azure.VMSS.PublicKey' -Ref 'AZR-000288' -Type 'Microsoft.Compute/virtualMachineScaleSets' -If { VMSSHasLinuxOS } -Tag @{ release = 'GA'; ruleSet = '2022_09' } {
    $Assert.In($TargetObject, 'properties.virtualMachineProfile.OsProfile.linuxConfiguration.disablePasswordAuthentication', $True).
    Reason($LocalizedData.VMSSPublicKey, $PSRule.TargetName)
}

#endregion Virtual machine scale set