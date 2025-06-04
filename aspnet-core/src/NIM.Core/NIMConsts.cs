using NIM.Debugging;

namespace NIM;

public class NIMConsts
{
    public const string LocalizationSourceName = "NIM";

    public const string ConnectionStringName = "Default";

    public const bool MultiTenancyEnabled = true;


    /// <summary>
    /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
    /// </summary>
    public static readonly string DefaultPassPhrase =
        DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "5d74c069c5234803887d8c6cfd60e16d";
}
