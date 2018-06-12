﻿Imports System.Web.Optimization
Imports Microsoft.WindowsAzure
Imports Microsoft.WindowsAzure.ServiceRuntime

Public Class Global_asax
    Inherits HttpApplication

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application is started
        'BundleConfig.RegisterBundles(BundleTable.Bundles)

        ' This code sets up a handler to update CloudStorageAccount instances when their corresponding
        ' configuration settings change in the service configuration file.
        ' Provide the configSetter with the initial value
        CloudStorageAccount.SetConfigurationSettingPublisher(Sub(configName, configSetter) configSetter(RoleEnvironment.GetConfigurationSettingValue(configName)))

        AuthConfig.RegisterOpenAuth()
    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires at the beginning of each request
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires upon attempting to authenticate the use
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when an error occurs
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application ends
    End Sub
End Class