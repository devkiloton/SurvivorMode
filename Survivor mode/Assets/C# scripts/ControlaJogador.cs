using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaJogador : MonoBehaviour
{
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        // aqui criamos a variável x, que corresponde as coordenadas do eixo x. com o comando "Input", acessamos a aba edit/project settings/
        // inputmanager, com isso, podemos usar o comando "GetAxis" para podermos digitar o eixo desejado entre parênteses. Selecionando
        // "Horizontal", temos acesso ao eixo x com as teclas predefinidas left e right ou a e d! o mesmo acontece com y.

        Vector3 eixos = new Vector3(x, 0, z);
        // como atribuimos às variáveis x e y os valores das coordenadas x e y, podemos colocar essas variáveis/comandos no Vector3.

        transform.Translate(eixos * 7 * Time.deltaTime);
        // Atualização: A unity por padrão deixa a movimentação de acordo com o o frame rate. Se eu tenho 500fps, na unity o objeto se movimenta
        // a a 500 unidades(quadrados que ficam no chão) por segundo, e essa taxa pode variar de acordo com o frame rate. Para solucionar isso
        // o Time.deltaTime faz o objeto andar uma unidade por segundo, se quisermos aumentar a taxa, é só multiplicar!
        //Atualização: feita a inserção de x e z no Vector3, só precisamos inserir "eixos" no translate que nossos comando serão seguidos
        // pelo nosso objeto(personagem).
        //transform = lugar onde são dadas as coordenadas na unity
        //Translate = comando para movimentação, translado!
        //Vector3 = lugar onde estão as coordenadas x,y,z.
        //forward = ir para frente em inglês, empurra o objeto no eixo z!

        if (eixos != Vector3.zero)
        {
            GetComponent<Animator>().SetBool("movendo", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("movendo", false);
        }
        /*o que fiz aqui foi ir no controller do "jogador 1" e, como por padrão o personagem apenas se movia por causa do estado mover,
        adicionei um estado chamado idle em que ele fica parado. Feito isso, fiz transições de um estado para o outro em ambos os estados, para
        que o personagem não ficasse em um loop infinito de se mover e parar, adicionei um parâmetro bool no animator chamado "movendo", após isso
        usei-o como condicional em ambas as transições.
        feita essa parte na unity, modifiquei o código formando a condicional acima em que Vector3.zero siginifica que não há movimentação,
        GetComponent<>()* busca uma componente para nós, componentes são basicamente as diversas abas do unity, após isso usei o comando 
        SetBool("movendo", true/false) em que movendo é o parametro na unity e true/false é o bool que movendo assume ou não. */



    }
}
