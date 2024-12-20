using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PresentationScript : MonoBehaviour, IInteractable
{
    private string[] scripts = {"Good morning everyone. Today I'm going to talk about bioluminescence. Bioluminescence is the production and emission of light by a living organism. It's a fascinating phenomenon that occurs widely in marine life. But it's also found in some terrestrial organisms like fireflies and fungi. Bioluminescent organisms produce light through a chemical reaction. This reaction involves a light-emitting molecule called luciferin and an enzyme called luciferase. Different organisms have unique luciferin-luciferase pairs. This results in a variety of colors and patterns of light emission. Bioluminescence serves a variety of functions in different organisms. In many marine animals. it's used for camouflage. By emitting light that matches the surrounding environment. they can blend in and become virtually invisible to predators. Some organisms use bioluminescence to attract prey or mates. The anglerfish. for example. uses a glowing lure to attract unsuspecting prey.  Other organisms use it for defense. Some squid and jellyfish release bioluminescent fluids to startle or distract predators. giving them a chance to escape. One of the most well-known examples of bioluminescence is the firefly. Fireflies use their flashing lights for communication and courtship. Each species has its own unique flashing pattern. This allows them to recognize and attract potential mates. Bioluminescence has also inspired many technological applications. Scientists are studying bioluminescent organisms to develop new light sources. These could be used in medical imaging. environmental monitoring. and even lighting our homes. In conclusion. bioluminescence is a remarkable natural phenomenon. It plays a vital role in the lives of many organisms. From the depths of the ocean to the forests at night. bioluminescence continues to amaze and inspire us. Thank you.",
    "Good morning everyone. Today I'm going to talk about quantum computing. Quantum computing is a fascinating field that harnesses the principles of quantum mechanics to perform powerful calculations. Unlike classical computers which rely on bits to represent information as 0s or 1s. quantum computers use qubits. Qubits can represent 0. 1. or a combination of both simultaneously. This is due to a quantum phenomenon known as superposition. Another key concept in quantum computing is entanglement. Entanglement allows qubits to be linked together in such a way that they share the same fate. even when separated by vast distances. These quantum properties enable quantum computers to tackle problems that are currently intractable for classical computers. One such problem is factoring large numbers. This has significant implications for cryptography. Quantum computers could potentially break current encryption algorithms. which rely on the difficulty of factoring large numbers. However. this also opens up opportunities for developing new. more secure encryption methods. Another promising application of quantum computing is in drug discovery and materials science. Quantum computers can simulate molecular interactions with incredible accuracy. This could lead to the development of new drugs and materials with improved properties.  Furthermore. quantum computing has the potential to revolutionize fields like artificial intelligence and machine learning. By performing complex calculations much faster than classical computers. quantum computers could accelerate the development of more sophisticated AI algorithms. While quantum computing is still in its early stages of development. significant progress is being made. Companies like IBM. Google. and Microsoft are investing heavily in quantum computing research.  There are also numerous challenges that need to be overcome. such as building stable qubits and developing efficient quantum algorithms. In conclusion. quantum computing is a revolutionary technology with the potential to transform various fields. While there are still challenges to overcome. the future of quantum computing is bright. and we can expect to see significant advancements in the years to come. Thank you.",
    "Good morning everyone. Today I want to talk about the enduring power of Christian faith. Christianity, with its roots tracing back to the life and teachings of Jesus Christ, has been a profound force in shaping human history and culture for over two millennia. At its core, Christianity offers a message of hope, love, and redemption that continues to resonate with billions of people worldwide. One of the central tenets of Christianity is the belief in a loving God who created the universe and all that is in it. This belief provides a sense of purpose and meaning in life, offering comfort and guidance in times of uncertainty and hardship. The teachings of Jesus, emphasizing love, forgiveness, and compassion, serve as a moral compass for Christians, encouraging them to live a life of service to others and to strive for justice and peace. Throughout history, Christianity has inspired countless acts of charity, compassion, and social justice. Christian organizations and individuals have been at the forefront of efforts to alleviate poverty, provide healthcare, and promote education in communities around the world. The Christian faith has also played a pivotal role in the development of art, music, and literature, enriching human culture with its profound themes and inspiring expressions of faith. Christianity offers a sense of community and belonging to its adherents. Churches provide a place for worship, fellowship, and spiritual growth, fostering a sense of shared values and mutual support among believers. This sense of community can be a source of strength and resilience in times of personal or societal challenges. While Christianity has faced its share of challenges and criticisms throughout history, its core message of hope, love, and redemption continues to inspire and transform lives. The Christian faith provides a framework for understanding the human condition, offering guidance for navigating life's complexities and finding meaning in both joy and sorrow. In conclusion, Christianity stands as a testament to the enduring power of faith, hope, and love. Its teachings and values have shaped human civilization for centuries, inspiring acts of compassion, creativity, and social progress. In a world often marked by uncertainty and division, the Christian faith offers a beacon of hope, reminding us of the transformative power of love, forgiveness, and the pursuit of a better world. Thank you"
    };

    [SerializeField] int scriptIndex;

    public GameObject ScriptObject;
    private Button[] buttons;

    // Start is called before the first frame update
    void Start()
    {
        buttons = FindObjectsOfType<Button>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnInteract()
    {
        ScriptObject.gameObject.GetComponent<Shim_BackScript>().SetScript(scripts[scriptIndex]);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].gameObject.SetActive(false);
        }
    }

    public void OnInteract(int QuestType)
    {
        throw new System.NotImplementedException();
    }

    // public void OnInteract()
    // {
    //     Debug.Log("Shim_MenuButton, OnInteract() function called");
    //     ToMainMenu();
    // }
}
