using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;
using System;

public class NotificationManager : MonoBehaviour
{
    public static NotificationManager Instance { get; private set; }

    AndroidNotificationChannel notifChannel;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        AndroidNotificationCenter.CancelAllDisplayedNotifications();
        AndroidNotificationCenter.CancelAllScheduledNotifications();

        notifChannel = new AndroidNotificationChannel()
        {
            Id = "reminder_notif_ch",
            Name = "Reminder Notification",
            Description = "Disturb the User",
            Importance = Importance.High
        };

        AndroidNotificationCenter.RegisterNotificationChannel(notifChannel);

        DisplayNotification("Vuelve, que sin ti la vida se me va", "Vuelveeeeeeeeeeee", DateTime.Now.AddHours(36));
    }

    /// <summary>
    /// Display title, text & time (in hours)
    /// </summary>
    /// <param name="title"></param>
    /// <param name="text"></param>
    /// <param name="fireTime"></param>
    /// <returns></returns>
    public int DisplayNotification(string title, string text, DateTime fireTime)
    {
        var notification = new AndroidNotification();
        notification.Title = title;
        notification.Text = text;
        notification.SmallIcon = "icon_reminders";
        notification.LargeIcon = "icon_reminder";
        notification.FireTime = fireTime;

        return AndroidNotificationCenter.SendNotification(notification, notifChannel.Id);
    }

    public void CancelNotification(int id)
    {
        AndroidNotificationCenter.CancelScheduledNotification(id);
    }
}
