using System;
using System.Security.Cryptography;
using System.Text;

namespace ssl
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // the data to be encrypted
            string dataToEncrypt = "Amir kian";

            // convert the public key string to a byte array
            byte[] publicKeyBytes = Convert.FromBase64String("MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEApFq4NaqdpTJjQkZlA0cPPDMbIfEg1XTVjsV5N4mwMgiYXizJBpySTcV8QY9Eb1UQ4Ewvm9z6VBS69kNuYXafo0gF/cdP/U3zyX55WMIJclyPpjfw15WUkfndqnAZ8ibyTL85uxYlHbUg00omiUM0KkoQ93Nw7fJT+fbi1noPlp0Ut6izggJEQOzvnxdlXus1oGuyNTmITIBm/K0mVxXA3aGloxW1OFzLv/dQF0FMXAL37cy4/jFKNAvrw3HfuR3admivGHpmKy61OKaJvHppA5n0c3KjHmpduLI9s8P/8sFVSoEUUuiB1uSVHKwDh2yZfuefYgj3zkUA6GsocSaheQIDAQAB");

            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.ImportSubjectPublicKeyInfo(publicKeyBytes, out _);

            // create an RSACryptoServiceProvider object and load the public key
            //RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            //rsa.ImportRSAPublicKey(publicKeyBytes, out _);

            // convert the data to a byte array
            byte[] dataBytes = Encoding.UTF8.GetBytes(dataToEncrypt);

            // encrypt the data using the public key
            byte[] encryptedData = rsa.Encrypt(dataBytes, true);

            // convert the encrypted data to a base64-encoded string
            string base64EncryptedData = Convert.ToBase64String(encryptedData);

            //****************************************************************************
            // the data to be encrypted

            // convert the encrypted data from base64 to a byte array
            byte[] encryptedData2 = Convert.FromBase64String(base64EncryptedData);

            // convert the private key string to a byte array
            byte[] privateKeyBytes = Convert.FromBase64String("MIIEvgIBADANBgkqhkiG9w0BAQEFAASCBKgwggSkAgEAAoIBAQCkWrg1qp2lMmNCRmUDRw88Mxsh8SDVdNWOxXk3ibAyCJheLMkGnJJNxXxBj0RvVRDgTC + b3PpUFLr2Q25hdp + jSAX9x0 / 9TfPJfnlYwglyXI + mN / DXlZSR + d2qcBnyJvJMvzm7FiUdtSDTSiaJQzQqShD3c3Dt8lP59uLWeg + WnRS3qLOCAkRA7O + fF2Ve6zWga7I1OYhMgGb8rSZXFcDdoaWjFbU4XMu / 91AXQUxcAvftzLj + MUo0C + vDcd + 5Hdp2aK8YemYrLrU4pom8emkDmfRzcqMeal24sj2zw//ywVVKgRRS6IHW5JUcrAOHbJl+559iCPfORQDoayhxJqF5AgMBAAECggEABQThtv7Xu1uhcRzP + SSGhDS91YCk + 2vK2UYxzFbDtxVw3MBin7VwmNgo8iIXSYyYHDdrZUe / a8mpx3s579dE6wI4L56ydEZ5BUxb1ZBwZCoMN3viGp1OaRJPuQSdIDpdACe / UjWsCr8VKmqraFnxagCyybHAbz3NH3cxCHJ4DyX +le1YNU / 4XCAnyVn9GqW5Qf / O7SibVMCm8hsP1dQUiqrskA2rUPhEVkwDMyVWLflHveXuO40JPbFEbGk9SPitsSq7LcAxt76RIqvFhBWj0lxF5hq4advSxpcPD3z + 4 / 7jvNObYbPBr3OIJCEsV8PwzeLNAVh3oGsKbaWAee7zoQKBgQDaz9nHhsDsUfE5ZYUbHtYZEdWy8fms / b8FjsKhMFgNOD + mBAuRuWlIhcugrY87a9pXu0I54n81migSdzPdGeP7E7 / NUJ01LgY / lddvgpQWQ0M77nDCmlKm4mxV2mWF3P8sqIsJTP7H1JygJPuPxTayQ2pezlyUjXILiUjmuvrGoQKBgQDASYKSrcQD / rboB55Z91KRxp5y5kDNJLTaEL9HBB6gswabnOY + d7KS765dIRGfcL9XskmAHivpTj63K6LDjOQuvhxTi3lLy1kMq3BgKh1WYXrWuPTT4 / r7EruQxFYZIPZ + LZzs + OFYxOdKocnAFP9S6Ja8lbk25fwuilQ9FURj2QKBgEYHxeys / SvlYe37xukSKnWllp6KAV3TbIKr2TDblyLMANryan1 +OOsEH1LSmYfsEdqITT7Xdd1C9FZMnmXCNowSGw3sIhR2IXvSSjwfL6QcbPVOb / poh9FvoDquBlYcj / LMEousf9KXAnXiwDyYYtQU7YNgSpMk3f5BNvrZlw9hAoGBALgKI6VMF15TfrDaCd / F7guEdMc4RjGSvl4wxUKtWLsqXlq2c1C6s / oa2WJdckaOXTUMeXjcZ97nevNKGoDb6tIqN2ZnCfNXb6XGuMnxxR6WMkItyHa9r8x7A3bt1BI9EG94LMhK9TRHUbCG5VipQC8UWqGpFBrNSO8qirHkFw8RAoGBAMEDPT1bjhGGIfWEEs4AjY / BXkFMwXENqDhWXtt0E4dJE / Pbp9ca1rs30nTUPf05Q345PRGQtHi4vOnT + TtSh1wcdbsnd5VKD2G + gjmvcZg / VJtFMCtSjKSY2MTHZps / KvMC + LjsHJ3J4zlLUN + zEz3EEDhaJgooZNiSsyLo5A6P");

            // create an RSACryptoServiceProvider object
            RSACryptoServiceProvider rsa2 = new RSACryptoServiceProvider();
            rsa2.ImportPkcs8PrivateKey(privateKeyBytes, out _); // Fix 1: use ImportPkcs8PrivateKey

            /*
            // create an RSAParameters object to hold the private key parameters
            RSAParameters privateKeyParams = new RSAParameters();

            // set the private key parameters from the byte array
            privateKeyParams.Modulus = publicKeyBytes;
            privateKeyParams.D = privateKeyBytes;

            // import the private key parameters into the RSACryptoServiceProvider object
            rsa2.ImportParameters(privateKeyParams);
			*/

            // decrypt the data
            byte[] decryptedData = rsa2.Decrypt(encryptedData2, true); // Fix 2: rsa2 instaed of rsa (typo); Fix3: true instead of false (apply the same padding)

            // display the decrypted data
            Console.WriteLine("Decrypted data: " + Encoding.UTF8.GetString(decryptedData));
        }//end main 

    }
}
