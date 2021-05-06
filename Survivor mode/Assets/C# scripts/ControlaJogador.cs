using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaJogador : MonoBehaviour
{
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        // aqui criamos a vari�vel x, que corresponde as coordenadas do eixo x. com o comando "Input", acessamos a aba edit/project settings/
        // inputmanager, com isso, podemos usar o comando "GetAxis" para podermos digitar o eixo desejado entre par�nteses. Selecionando
        // "Horizontal", temos acesso ao eixo x com as teclas predefinidas left e right ou a e d! o mesmo acontece com y.

        Vector3 eixos = new Vector3(x, 0, z);
        // como atribuimos �s vari�veis x e y os valores das coordenadas x e y, podemos colocar essas vari�veis/comandos no Vector3.

        transform.Translate(eixos * 7 * Time.deltaTime);
        // Atualiza��o: A unity por padr�o deixa a movimenta��o de acordo com o o frame rate. Se eu tenho 500fps, na unity o objeto se movimenta
        // a a 500 unidades(quadrados que ficam no ch�o) por segundo, e essa taxa pode variar de acordo com o frame rate. Para solucionar isso
        // o Time.deltaTime faz o objeto andar uma unidade por segundo, se quisermos aumentar a taxa, � s� multiplicar!
        //Atualiza��o: feita a inser��o de x e z no Vector3, s� precisamos inserir "eixos" no translate que nossos comando ser�o seguidos
        // pelo nosso objeto(personagem).
        //transform = lugar onde s�o dadas as coordenadas na unity
        //Translate = comando para movimenta��o, translado!
        //Vector3 = lugar onde est�o as coordenadas x,y,z.
        //forward = ir para frente em ingl�s, empurra o objeto no eixo z!

        if (eixos != Vector3.zero)
        {
            GetComponent<Animator>().SetBool("movendo", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("movendo", false);
        }
        /*o que fiz aqui foi ir no controller do "jogador 1" e, como por padr�o o personagem apenas se movia por causa do estado mover,
        adicionei um estado chamado idle em que ele fica parado. Feito isso, fiz transi��es de um estado para o outro em ambos os estados, para
        que o personagem n�o ficasse em um loop infinito de se mover e parar, adicionei um par�metro bool no animator chamado "movendo", ap�s isso
        usei-o como condicional em ambas as transi��es.
        feita essa parte na unity, modifiquei o c�digo formando a condicional acima em que Vector3.zero siginifica que n�o h� movimenta��o,
        GetComponent<>()* busca uma componente para n�s, componentes s�o basicamente as diversas abas do unity, ap�s isso usei o comando 
        SetBool("movendo", true/false) em que movendo � o parametro na unity e true/false � o bool que movendo assume ou n�o. */



    }
}
