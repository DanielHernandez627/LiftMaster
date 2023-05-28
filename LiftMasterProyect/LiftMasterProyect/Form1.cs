using System.Windows.Forms;

namespace LiftMasterProyect
{
    public partial class Master : Form
    {

        private System.Windows.Forms.Timer _Timer = new System.Windows.Forms.Timer();
        private int count = 0;
        private int[] _pisosGlobal;
        private int _pisosTotalGlobal = 0;
        private static List<Button> buttonMovement = new List<Button>();
        private static List<Button> buttonAwait = new List<Button>();
        private static List<Button> buttonStop = new List<Button>();
        Logic.Utilities util = new Logic.Utilities();

        public Master()
        {
            InitializeComponent();
            util.EscribirLog("Inicio del Programa");
            Init_Button();
            _Timer = new System.Windows.Forms.Timer();
            _Timer.Interval = 3000;
            _Timer.Tick += new EventHandler(Floor_change);
        }

        private void btn_process_Click(object sender, EventArgs e)
        {
            Logic.Elevator_algorithm _Algorithm = new Logic.Elevator_algorithm();
            Logic.Algorithm_constants _Constants = new Logic.Algorithm_constants();

            #region LecturaPesos
            int limitePersonas = _Constants.GetCantMaxPersonas();
            Tuple<int>[] personas;
            personas = _Algorithm.Amount_of_people();
            int pesoTotal = 0;


            list_pesos.Items.Clear();
            for (int i = 0; i < personas.Length; i++)
            {
                pesoTotal += personas[i].Item1;
                list_pesos.Items.Add(personas[i].Item1);
            }
            txt_Peso.Text = pesoTotal.ToString();

            util.EscribirLog("Peso total en el ascensor: "+pesoTotal.ToString());
            #endregion

            #region LecturaPisos
            int[] pisos = _Algorithm.Floor_to_climb(personas.Length);
            _pisosGlobal = pisos;
            string pisos_text = "";
            for (int i = 0; i < pisos.Length; i++)
            {
                if (pisos[i] != 0)
                {
                    if (i == 5)
                    {
                        pisos_text = pisos_text + pisos[i].ToString();
                    }
                    else
                    {
                        pisos_text = pisos_text + pisos[i].ToString() + ",";
                    }
                    _pisosTotalGlobal++;
                }
            }

            txt_Pisos.Text = pisos_text;
            _pisosTotalGlobal = pisos.Length;
            util.EscribirLog("Pisos a recorrer: " + pisos_text.ToString());
            #endregion

            State_Color_Button_Init();
        }

        private void btn_excfilt_Click(object sender, EventArgs e)
        {
            Floors_to_Go(_pisosGlobal);
            State_Floors_Movement(Color.Green);
            _Timer.Start();
        }

        private void Floor_change(object sender, EventArgs e)
        {

            if (count >= _pisosTotalGlobal)
            {
                State_Floors_Movement(Color.Gray);
                _Timer.Stop();
            }
            else
            {
                Array.Sort(_pisosGlobal);
                _pisosTotalGlobal = _pisosGlobal.Length;
                if (_pisosGlobal[count] != 0)
                {
                    Control_Floor(_pisosGlobal[count]);
                }
            }
            count++;
        }

        #region ControlBotones
        private void Init_Button()
        {
            //Inicializacion listas de Botones
            buttonMovement.Add(btn_stateclose1);
            buttonMovement.Add(btn_stateclose2);
            buttonMovement.Add(btn_stateclose3);
            buttonMovement.Add(btn_stateclose4);
            buttonMovement.Add(btn_stateclose5);
            buttonMovement.Add(btn_stateclose6);

            buttonAwait.Add(btn_statewait1);
            buttonAwait.Add(btn_statewait2);
            buttonAwait.Add(btn_statewait3);
            buttonAwait.Add(btn_statewait4);
            buttonAwait.Add(btn_statewait5);
            buttonAwait.Add(btn_statewait6);


            buttonStop.Add(btn_stateopen1);
            buttonStop.Add(btn_stateopen2);
            buttonStop.Add(btn_stateopen3);
            buttonStop.Add(btn_stateopen4);
            buttonStop.Add(btn_stateopen5);
            buttonStop.Add(btn_stateopen6);
        }

        private void State_Color_Button_Init()
        {
            foreach (Button btn in buttonMovement)
            {
                btn.BackColor = Color.Gray;
            }

            foreach (Button btn2 in buttonAwait)
            {
                btn2.BackColor = Color.Gray;
            }

            foreach (Button btn3 in buttonStop)
            {
                btn3.BackColor = Color.Gray;
            }
        }

        private void Control_Floor(int piso)
        {
            util.EscribirLog("Movimiento hacia el piso "+ piso.ToString());
            switch (piso)
            {
                case 2:
                    State_Floors_Stop(Color.Red, piso);
                    break;
                case 3:
                    State_Floors_Stop(Color.Red, piso);
                    break;
                case 4:
                    State_Floors_Stop(Color.Red, piso);
                    break;
                case 5:
                    State_Floors_Stop(Color.Red, piso);
                    break;
                case 6:
                    State_Floors_Stop(Color.Red, piso);
                    break;
                default:
                    break;

            }
        }

        private void Floors_to_Go(int[] pisos)
        {
            int numero=0;
            for (int i = 0; i <= pisos.Length-1; i++)
            {
                numero = pisos[i];

                switch (numero)
                {
                    case 2:
                        btn_statewait2.BackColor = Color.Yellow;
                        break;
                    case 3:
                        btn_statewait3.BackColor = Color.Yellow;
                        break;
                    case 4:
                        btn_statewait4.BackColor = Color.Yellow;
                        break;
                    case 5:
                        btn_statewait5.BackColor = Color.Yellow;
                        break;
                    case 6:
                        btn_statewait6.BackColor = Color.Yellow;
                        break;
                    default:
                        break;
                }
            }
            util.EscribirLog("Se realiza configuracion de botones de espera dependiendo de los pisos a recorrer");
        }

        private void State_Floors_Movement(Color color)
        {
            foreach (Button btn in buttonMovement)
            {
                btn.BackColor = color;
            }
        }

        private void State_Floors_Stop(Color color, int piso)
        {
            int numero = 0;
                numero = piso;

            switch (numero)
            {
                case 2:
                    btn_stateopen2.BackColor = color;
                    btn_statewait2.BackColor = Color.Gray;
                    util.EscribirLog("Se detiene en el piso 2");
                    break;
                case 3:
                    btn_stateopen3.BackColor = color;
                    btn_statewait3.BackColor = Color.Gray;
                    util.EscribirLog("Se detiene en el piso 3");
                    break;
                case 4:
                    btn_stateopen4.BackColor = color;
                    btn_statewait4.BackColor = Color.Gray;
                    util.EscribirLog("Se detiene en el piso 4");
                    break;
                case 5:
                    btn_stateopen5.BackColor = color;
                    btn_statewait5.BackColor = Color.Gray;
                    util.EscribirLog("Se detiene en el piso 5");
                    break;
                case 6:
                    btn_stateopen6.BackColor = color;
                    btn_statewait6.BackColor = Color.Gray;
                    util.EscribirLog("Se detiene en el piso 6");
                    break;
                default:
                    break;
            }
        }

        #endregion
    }
}