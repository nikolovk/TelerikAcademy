using System;
using System.Collections.Generic;
using System.Linq;

public class DocumentSystem
{
    public static List<Document> allDocuments = new List<Document>();

    static void Main()
    {
        IList<string> allCommands = ReadAllCommands();
        ExecuteCommands(allCommands);
    }

    private static IList<string> ReadAllCommands()
    {
        List<string> commands = new List<string>();
        while (true)
        {
            string commandLine = Console.ReadLine();
            if (commandLine == "")
            {
                // End of commands
                break;
            }
            commands.Add(commandLine);
        }
        return commands;
    }

    private static void ExecuteCommands(IList<string> commands)
    {
        foreach (var commandLine in commands)
        {
            int paramsStartIndex = commandLine.IndexOf("[");
            string cmd = commandLine.Substring(0, paramsStartIndex);
            int paramsEndIndex = commandLine.IndexOf("]");
            string parameters = commandLine.Substring(
                paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
            ExecuteCommand(cmd, parameters);
        }
    }

    private static void ExecuteCommand(string cmd, string parameters)
    {
        string[] cmdAttributes = parameters.Split(
            new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        if (cmd.Substring(0, 3) == "Add")
        {
            AddDocument(cmdAttributes, cmd);
        }
        else if (cmd == "ListDocuments")
        {
            ListDocuments();
        }
        else if (cmd == "EncryptDocument")
        {
            EncryptDocument(parameters);
        }
        else if (cmd == "DecryptDocument")
        {
            DecryptDocument(parameters);
        }
        else if (cmd == "EncryptAllDocuments")
        {
            EncryptAllDocuments();
        }
        else if (cmd == "ChangeContent")
        {
            ChangeContent(cmdAttributes[0], cmdAttributes[1]);
        }
        else
        {
            throw new InvalidOperationException("Invalid command: " + cmd);
        }
    }

    private static void AddDocument(string[] attributes, string cmd)
    {
        Document textDocument;
        switch (cmd)
        {
            case "AddTextDocument":
                textDocument = new TextDocument();
                break;
            case "AddPDFDocument":
                textDocument = new PDFDocument();
                break;
            case "AddWordDocument":
                textDocument = new WordDocument();
                break;
            case "AddExcelDocument":
                textDocument = new ExcelDocument();
                break;
            case "AddAudioDocument":
                textDocument = new AudioDocument();
                break;
            case "AddVideoDocument":
                textDocument = new VideoDocument();
                break;
            default:
                textDocument = new TextDocument();
                break;
        }

        if (attributes.Length > 0)
        {
            IList<KeyValuePair<string, object>> attrbList = new List<KeyValuePair<string, object>>();
            foreach (var attribute in attributes)
            {
                string[] attrPair = attribute.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                attrbList.Add(new KeyValuePair<string, object>(attrPair[0], attrPair[1] as object));
            }
            textDocument.SaveAllProperties(attrbList);
            allDocuments.Add(textDocument);
            Console.WriteLine("Document added: {0}", textDocument.Name);
        }
        else
        {
            Console.WriteLine("Document has no name");
        }
    }




    private static void ListDocuments()
    {
        foreach (var document in allDocuments)
        {
            Console.WriteLine(document);
        }
    }

    private static void EncryptDocument(string name)
    {
        List<Document> docs = allDocuments.FindAll(a => a.Name == name);

        if (docs.Count == 0)
        {
            Console.WriteLine("Document not found: " + name);
        }
        else
        {
            foreach (var doc in docs)
            {
                if (doc is IEncryptable)
                {
                    (doc as IEncryptable).Encrypt();
                    Console.WriteLine("Document encrypted: " + doc.Name);
                }
                else
                {
                    Console.WriteLine("Document does not support encryption: " + doc.Name);
                }
            }
        }

    }

    private static void DecryptDocument(string name)
    {
        List<Document> docs = allDocuments.FindAll(a => a.Name == name);

        if (docs.Count == 0)
        {
            Console.WriteLine("Document not found: " + name);
        }
        else
        {
            foreach (var doc in docs)
            {
                if (doc is IEncryptable)
                {
                    (doc as IEncryptable).Decrypt();
                    Console.WriteLine("Document decrypted: " + doc.Name);
                }
                else
                {
                    Console.WriteLine("Document does not support decryption: " + doc.Name);
                }
            }
        }
    }

    private static void EncryptAllDocuments()
    {
        List<Document> documents = allDocuments.FindAll(a => a is IEncryptable);
        if (documents.Count == 0)
        {
            Console.WriteLine("No encryptable documents found");
        }
        else
        {
            foreach (var document in documents)
            {
                (document as IEncryptable).Encrypt();
            }
            Console.WriteLine("All documents encrypted");
        }
    }

    private static void ChangeContent(string name, string content)
    {
        List<Document> docs = allDocuments.FindAll(a => a.Name == name);
        if (docs.Count == 0)
        {
            Console.WriteLine("Document not found: " + name);
        }
        else
        {
            foreach (var doc in docs)
            {
                if (doc is IEditable)
                {
                    (doc as IEditable).ChangeContent(content);
                    Console.WriteLine("Document content changed: " + doc.Name);
                }
                else
                {
                    Console.WriteLine("Document is not editable: " + doc.Name);
                }
            }
        }
    }
}
