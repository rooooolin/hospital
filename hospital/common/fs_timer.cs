using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentScheduler;
using GPush;
using BLL;
using Model;

namespace hospital.common
{
    public class fs_timer
    {
        public void add_follow_task(string ALIAS, string title, string text, string transmission_content, int role_id, string follow_time, int behav, string task_id, int d_id, string p_id_list_str)
        {
            DateTime task_time = DateTime.Parse(follow_time).AddDays(-1);
            System.TimeSpan task_span = DateTime.Parse(follow_time) - DateTime.Now;
            int day_interval = int.Parse(task_span.ToString().Split(new char[1] { '.' })[0]); 
            Registry registry = new Registry();
            registry.Schedule(() => execution_jod(ALIAS, title, text, transmission_content, role_id, task_time.ToString().Split()[0], behav, task_id, d_id, p_id_list_str)).WithName(task_id).ToRunNow().AndEvery(day_interval).Days();
            JobManager.Initialize(registry);
        }

        public void execution_jod(string ALIAS, string title, string text, string transmission_content, int role_id, string task_time, int behav, string task_id, int d_id, string p_id_list_str)
        {
            string[] text_list = text.Split(new char[1] { '|' });
            string[] transmission_content_list = transmission_content.Split(new char[1] { '|' });
            string push_result = "";
            if (behav == 1)
            {
                if (DateTime.Now.ToString().Split()[0] == task_time)
                {
                    push_result = push_message.PushMessageToSingle(ALIAS, title, text_list[1], transmission_content_list[1], role_id);
                    JobManager.RemoveJob(task_id);
                }
                else
                {
                    push_result = push_message.PushMessageToSingle(ALIAS, title, text_list[0], transmission_content_list[0], role_id);
                }
            }
            else if (behav == 2)
            {
                if (DateTime.Now.ToString().Split()[0] == task_time)
                {
                    push_result = push_message.PushMessageToList(ALIAS, title, text_list[1], transmission_content_list[1], role_id);
                    JobManager.RemoveJob(task_id);
                }
                else
                {
                    push_result = push_message.PushMessageToList(ALIAS, title, text_list[0], transmission_content_list[0], role_id);
                } 
            }
            bll_push push = new bll_push();
            model_pushlog model = new model_pushlog();
            model.activator = d_id.ToString();
            model.target = p_id_list_str;
            model.push_time = System.DateTime.Now.ToString();
            model.result = push_result;
            model.remarks = "医生发起随访";
            push.add_push_log(model);
        }

    }
}