using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Linq;
using System.Collections;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace TestApp.Mocking.Edu;

public class Student
{
    public string FullName { get; set; }
    public string Email { get; set; }

}

public enum MessageBoxButtons { Ok }
public enum MessageBoxStyle { Info, Error }
public class XtraMessageBox
{
    public static void Show(string title, string message, MessageBoxStyle messageBoxStyle, MessageBoxButtons messageBoxButtons)
    {

    }
}

public abstract class DbContext
{
}

public abstract class DbSet<T> : IQueryable<T>
    where T : class
{
    public Type ElementType => throw new NotImplementedException();

    public Expression Expression => throw new NotImplementedException();

    public IQueryProvider Provider => throw new NotImplementedException();

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}

public class ApplicationContext : DbContext
{
    public DbSet<Student> Students { get; set; }
}

public class SmtpOptions
{
    public string SmtpHost { get; set; }
    public int SmtpPort { get; set; }
    public string SmtpUsername { get; set; }
    public string SmtpPassword { get; set; }
    public string EmailFrom { get; set; }
    public string NameFrom { get; set; }
}

public class CertificateService
{

    public bool SendEmails(DateTime certificateDate)
    {
        var db = new ApplicationContext();

        var students = db.Students;

        foreach (var student in students)
        {
            if (student.Email == null)
                continue;

            var statementFilename = SaveCertificate(student.FullName, certificateDate);

            try
            {
                EmailFile(student.Email, "Hello", statementFilename, "Your certificate");
            }
            catch (Exception e)
            {
                XtraMessageBox.Show(e.Message, string.Format("Email failure: {0}", student.Email), MessageBoxStyle.Error, MessageBoxButtons.Ok);

                return false;
            }
        }

        return true;

    }

    private static string SaveCertificate(string name, DateTime certificateDate)
    {
        var report = new StatementReport(name, certificateDate);

        if (!report.HasData)
            return string.Empty;

        report.CreateDocument();

        var filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            $"Statement {certificateDate:yyyy-MM} {name}.pdf");


        report.ExportToPdf(filename);

        return filename;
    }

    private static void EmailFile(string emailAddress, string body, string filename, string subject)
    {
        SmtpOptions smtpOptions = new SmtpOptions();

        var client = new SmtpClient(smtpOptions.SmtpHost, smtpOptions.SmtpPort)
        {
            Credentials = new NetworkCredential(smtpOptions.SmtpUsername, smtpOptions.SmtpPassword)
        };

        var from = new MailAddress(smtpOptions.EmailFrom, smtpOptions.NameFrom);

        var to = new MailAddress(emailAddress);

        var message = new MailMessage(from, to)
        {
            Subject = subject,
            SubjectEncoding = Encoding.UTF8,
            Body = body,
            BodyEncoding =  Encoding.UTF8,
        };

        // Add attachment
        if (!string.IsNullOrEmpty(filename) && File.Exists(filename))
        {
            Attachment attachment = new Attachment(filename);
            message.Attachments.Add(attachment);
        }

        client.Send(message);
        message.Dispose();
        File.Delete(filename);

    }

    public class StatementReport
    {
        public string Name { get; set; }
        public DateTime CertificateDate { get; set; }

        public StatementReport(string name, DateTime certificateDate)
        {
            Name = name;
            CertificateDate = certificateDate;
        }

        public bool HasData => !string.IsNullOrEmpty(Name);

        public void CreateDocument()
        {

        }

        public void ExportToPdf(string filename)
        {

        }
    }
}
