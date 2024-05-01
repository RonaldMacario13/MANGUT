using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public Image image;
    public Text loadingText;

    readonly List<string> loadingPhrases = new()
    {
            "Você sabia que a pipoca é saudável? Ela é cheia de fibras e nutrientes, e quando preparada sem adições prejudiciais, é uma ótima opção de lanche natural. É deliciosa e faz bem para o corpo!",
            "Já parou para pensar que uma maçã por dia pode realmente manter o médico longe? Essa fruta incrível é rica em vitaminas e fibras, promovendo saúde e bem-estar.",
            "Quem diria que o chocolate amargo poderia ser um aliado da saúde? Com seus antioxidantes e outros nutrientes, ele pode contribuir para a saúde do coração e até mesmo do cérebro.",
            "Você já experimentou um punhado de nozes hoje? Esses pequenos superalimentos são repletos de ácidos graxos saudáveis, proteínas e fibras, fazendo maravilhas pelo seu corpo.",
            "Que tal substituir refrigerantes por água de coco? Além de ser refrescante, ela é uma fonte natural de eletrólitos, ideal para hidratar e repor nutrientes após o exercício.",
            "O abacate não é apenas um ingrediente delicioso para guacamole; ele também é repleto de gorduras saudáveis que podem ajudar a manter seu coração em forma.",
            "Você já considerou trocar o açúcar refinado pelo mel de verdade? Além de adoçar suas receitas, ele contém antioxidantes e outros nutrientes benéficos para o corpo.",
            "Ao invés de salgadinhos processados, que tal optar por chips de vegetais? Eles são crocantes, cheios de sabor e proporcionam uma dose extra de vitaminas e minerais.",
            "O iogurte grego é uma excelente fonte de proteínas e probióticos, o que o torna não apenas delicioso, mas também benéfico para a saúde intestinal.",
            "As sementes de chia podem parecer pequenas, mas seus benefícios para a saúde são enormes! Elas são carregadas com ômega-3, fibras e proteínas, ótimas para energia sustentada ao longo do dia.",
            "E se eu te disser que um punhado de mirtilos por dia pode ajudar a melhorar sua memória? Essas pequenas frutas são ricas em antioxidantes e compostos que podem beneficiar a saúde do cérebro."
    };

    void Start() {
        int rand = Random.Range(0, loadingPhrases.Count-1);

        loadingText.text = loadingPhrases[rand];
    }
}
