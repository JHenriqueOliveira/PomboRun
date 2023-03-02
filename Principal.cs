using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public enum SIDE { left,mid, right}
public class pombo : MonoBehaviour
{
    private bool loop = true;
    bool duplicador = false;
    public SIDE moverlado = SIDE.mid;
    float novaposicaox = 0f;
    public float valorx;
    public bool SwipeRight, SwipeLeft, SwipeDown, SwipeUp;
    public float velocidadeatual;
    float poderpulo = 10f;
    private float x;
    private float y;
    static public bool injump;
    public bool inroll;
    float speeddodge = 10f;
    private float colheight;
    private float colcentery;
    private Vector2 touchorigin;
    Vector2 touchOrigin;

    public CharacterController moverpersonagem;
    public Animator anim;
    public AudioSource audiomoeda;
    public AudioSource audiocronometro;
    

    void Start()
    {
        anim.SetTrigger("Ressucitado");
        rapidez.speed = -20;
        StartCoroutine(velocidade());
        StartCoroutine(distancia());
        moverpersonagem = GetComponent<CharacterController>();
        colheight = moverpersonagem.height;
        colcentery = moverpersonagem.center.y;
        transform.position = Vector3.zero;
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        //Inputs
        SwipeLeft = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
        SwipeRight = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);
        SwipeUp = Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);
        SwipeDown = Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow);

        //Controladores para mobile
#if UNITY_ANDROID || UNITY_IOS
        if (Input.touchCount > 0)
        {
            Touch myTouch = Input.touches[0];

            if (myTouch.phase == TouchPhase.Began)
            {
                touchOrigin = myTouch.position;
            }
            else if (myTouch.phase == TouchPhase.Ended)
            {
                Vector2 touchEnd = myTouch.position;

                Vector2 distance = touchEnd - touchOrigin;

                if (Mathf.Abs(distance.x) > Mathf.Abs(distance.y))
                {
                    Debug.Log("HorizontalSwipe");
                    if (Mathf.Sign(distance.x) > 0)
                    {
                        if (moverlado == SIDE.mid)
                        {
                            novaposicaox = valorx;
                            moverlado = SIDE.right;
                            
                        }
                        else if (moverlado == SIDE.left)
                        {
                            novaposicaox = 0;
                            moverlado = SIDE.mid;
                            
                        }
                    }
                    else if (Mathf.Sign(distance.x) < 0)
                    {
                        if (moverlado == SIDE.mid)
                        {
                            novaposicaox = -valorx;
                            moverlado = SIDE.left;
                           
                        }
                        else if (moverlado == SIDE.right)
                        {
                            novaposicaox = 0;
                            moverlado = SIDE.mid;
                          
                        }
                    }
                }
                else if (Mathf.Abs(distance.x) < Mathf.Abs(distance.y))
                {
                    Debug.Log("VerticalSwipe");
                    if (Mathf.Sign(distance.y) > 0)
                    {
                        if (moverpersonagem.isGrounded)
                        {
           
                                 y = poderpulo;
                                 injump = true;
                                 anim.SetTrigger("Pulo");
            

                        }
                        else
                         {
                            y -= poderpulo * Time.deltaTime;
                            anim.SetTrigger("Chao");

                         }
                    }
                    else if (Mathf.Sign(distance.y) < 0)
                    {
                        moverpersonagem.center = new Vector3(0, colcentery / 2f, 0);
            colheight = moverpersonagem.height / 2f;
            rollcounter = 0.2f;
            y -= 10f;
            inroll = true;
            injump = false;
                        anim.SetTrigger("Rolar");
                    }
                }
            }

        }
        #endif
         #if UNITY_STANDALONE_WIN

      //Controladores
      if (SwipeLeft)
        {
            if (moverlado == SIDE.mid)
            {
                novaposicaox = -valorx;
                moverlado = SIDE.left;
                
            }
            else if (moverlado == SIDE.right)
            {
                novaposicaox = 0;
                moverlado = SIDE.mid;
                
            }
        }
        if (SwipeRight)
        {
            if (moverlado == SIDE.mid)
            {
                novaposicaox = valorx;
                moverlado = SIDE.right;
                
            }
            else if (moverlado == SIDE.left)
            {
                novaposicaox = 0;
                moverlado = SIDE.mid;
                
            }
        }
#endif

        Vector3 moveVector = new Vector3(x - transform.position.x, y * Time.deltaTime, 0);
        x = Mathf.Lerp(x, novaposicaox, Time.deltaTime * speeddodge);
        moverpersonagem.Move(moveVector);
        Jump();
        Roll();

    }

    public void Jump()
    {
        if (moverpersonagem.isGrounded)
        {
            if (SwipeUp)
            {
                y = poderpulo;
                injump = true;
                anim.SetTrigger("Pulo");
            }

        }
        else
        {
            y -= poderpulo * Time.deltaTime * 2;
            injump = false;
            anim.SetTrigger("Chao");
        }

    }
    internal float rollcounter;
    public void Roll()
    {
        rollcounter -= Time.deltaTime;
        if (rollcounter <= 0f)
        {
            rollcounter = 0f;
            moverpersonagem.center = new Vector3(0, colcentery, 0);
            colheight = moverpersonagem.height;
            inroll = false;
            anim.SetTrigger("Desrolar");
        }
        if (SwipeDown)
        {
            moverpersonagem.center = new Vector3(0, colcentery / 2f, 0);
            colheight = moverpersonagem.height / 2f;
            rollcounter = 0.2f;
            y -= 10f;
            anim.SetTrigger("Rolar");
            inroll = true;
            injump = false;
        }
    }

    //Coleta de itens e moedas
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "powerUp")
        {
            audiocronometro.Play();
            Destroy(other.gameObject);
            StartCoroutine(cooldownZawarudo()); 
        }
        if (other.tag == "moeda")
        {
            Destroy(other.gameObject);
            if (duplicador == true)
            {
                UIscr.moedajogo = UIscr.moedajogo + 2;
                UIscr.moedas = UIscr.moedas + 2;
            }
            else
            {
                UIscr.moedajogo++;
                UIscr.moedas++;
            }
            audiomoeda.Play();
        }
        if (other.tag == "duplicador")
        {
            duplicador = true;
            Destroy(other.gameObject);
            StartCoroutine(cooldownduplicador());
        }
        if (other.tag == "drone")
        {
            Destroy(other.gameObject);
        }
        if (other.tag == "assassino")
        {
            StartCoroutine(morrer());
        }
    }

    //corrotinas
   IEnumerator morrer()
    {
        rapidez.speed = 5;
        anim.SetTrigger("Morte");
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
        SceneManager.LoadScene("Deathscreen");    
    }
    IEnumerator cooldownZawarudo()
    {
        pausescript.pausado = 2;
        yield return new WaitForSeconds(3);
        pausescript.pausado = 1;
    }
    IEnumerator cooldownduplicador()
    {
        yield return new WaitForSeconds(10);
        duplicador = false;
    }
    IEnumerator velocidade()
    {
        while (rapidez.speed > -100f)
        {
            rapidez.speed -= 0.5f;
            yield return new WaitForSeconds(1);
        }
    }
    IEnumerator distancia()
    {
        while (loop == true)
        {
            UIscr.distancia++;
            yield return new WaitForSeconds(1);
        }
    }
}
public class rapidez
{
    public static float speed = -20f;
    }