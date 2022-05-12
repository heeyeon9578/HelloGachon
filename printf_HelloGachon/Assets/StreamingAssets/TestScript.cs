using UnityEngine;
using UnityEngine.UI;

// namespace doesnt matter, its here just for clarity
namespace RuntimeCSharpCompiler
{
    // it can even be the same as already existing type, what matters is its in different module
    public class TestLoadScript : MonoBehaviour
    {
        void Start()
        {
            Debug.Log("Script Starts");
        }

        void Update()
        {
            GetText();
            Debug.Log("Script On Running..");
        }

        void GetText()
        {
            string funcBodyText = GameObject.Find("FuncBody").GetComponent<InputField>().text;
            if (funcBodyText.Contains("printf"))
            {
                var output = GameObject.Find("Output").GetComponent<UnityEngine.UI.Text>();
                output.text = funcBodyText.Split('(', ')')[1];
                Debug.Log(output.text);
                // output = funcBodyText.Split('(', ')')[1];
                // Debug.Log(output);
            }
        }

        void HandlePrintf()
        {

        }

        void HandleForLoop()
        {

        }
    }

}