namespace LiftMasterProyect
{
    public partial class Master : Form
    {

        public Master()
        {
            InitializeComponent();
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
            int cantidad_Personas=0;
            list_pesos.Items.Clear();
            for (int i = 0; i < personas.Length; i++)
            {
                pesoTotal += personas[i].Item1;
                cantidad_Personas++;
                list_pesos.Items.Add(personas[i].Item1);
            }
            txt_Peso.Text = pesoTotal.ToString();
            txt_Personas.Text = cantidad_Personas.ToString();
            #endregion

            #region LecturaPisos
            int[] pisos = _Algorithm.Floor_to_climb(personas.Length);
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
                }
            }

            txt_Pisos.Text = pisos_text;
            #endregion
        }
    }
}