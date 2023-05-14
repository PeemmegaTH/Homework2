class Homework {
    static void Print(string text){
        Console.Write(text);
    }
    static void PrintN(string text){
        Console.WriteLine(text);
    }
    static int Fractoria(int n){
        if (n > 0){
            int total = 1;
            for (int i = 1; i <= n ; i++){
                total *= i;
            }
            return total;
        } else {
            return 1;    
        }
    }

    static string NumberToString (double Number){
        return Convert.ToString(Number);
    }

    static void PascalTriangle(){
        
        static int GetPascalTriangle(int n,int r){
            return (Fractoria(r) / (Fractoria(n) * Fractoria(r-n)));
        }

        Print("Input floor: ");
        int floor = int.Parse(Console.ReadLine());
        if (floor < 0) {
            PrintN("Invalid Pascal’s triangle row number.");
            PascalTriangle();
        }
        for (int r = 0 ; r <= floor ;r++){
            PrintN("");

            for (int n = 0; n <= r ; n++){
                int number_In_Position = GetPascalTriangle(n,r);
                Print(NumberToString(number_In_Position) + " ");
            }
        }
    }

    static void DNA(){
        static bool IsValidSequence(string halfDNASequence)
        {
            foreach(char nucleotide in halfDNASequence)
            {
                if(!"ATCG".Contains(nucleotide))
                {
                    return false;
                }
            }
            return true;
        }

        static string ReplicateSeqeunce(string halfDNASequence)
        {
            string result = "";
            foreach(char nucleotide in halfDNASequence)
            {
                result += "TAGC"["ATCG".IndexOf(nucleotide)];
            }
            return result;
        }

        Print("Input DNA: ");
        string dna = Console.ReadLine();
        
        if (IsValidSequence(dna)){
            PrintN("Current half DNA sequence : " + dna);
            Print("Do you want to replicate it ? (Y/N) : ");
            
            static void Replicate(string dna){
                switch (Console.ReadLine()) 
                {
                    case "Y":
                        string replicateDNA = ReplicateSeqeunce(dna);
                        PrintN("Replicated half DNA sequence : " + replicateDNA);
                        break;
                    case "N":
                        break;
                    default:
                        PrintN("Please input Y or N.");
                        Replicate(dna);
                        break;
                }
            }
            Replicate(dna);
    
        } else {
            PrintN("That half DNA sequence is invalid.");
        }

        
        
        static void Choices(){
                Print( "Do you want to process another sequence ? (Y/N) : ");
                switch (Console.ReadLine()) 
                {
                    case "Y":
                        DNA();
                        break;
                    case "N":
                        PrintN("End.");
                        break;
                    default:
                        PrintN("Please input Y or N.");
                        Choices();
                        break;
                }
            }
        Choices();
    }

    static void Legendary_Metrix(){
        Print("Input - or + to do Matrix: ");
        string command = Console.ReadLine();

        while(command == "+" || command == "-"){
            Print("Input Matrix Size (roll & colume): ");
            int roll = int.Parse(Console.ReadLine());
            int colume = int.Parse(Console.ReadLine());

            float [,] A = new float[roll,colume];
            float [,] B = new float[roll,colume];
                
            PrintN("Getting [A] Matrix");
            SetMetrixValue(ref A);
            PrintN("Getting [B] Matrix");
            SetMetrixValue(ref B);

            switch(command){
                case "+":
                    SumOfMatrix(A,B);
                    break;
                case "-":
                    NegativeOfMatrix(A,B);
                    break;      
            }

            Print("Input - or + to do Matrix: ");
            command = Console.ReadLine();
        }           

        static void SumOfMatrix(float[,] A,float[,] B){
            for (int r = 0;r < A.GetLength(0) ;r++){
                for (int c = 0;c < A.GetLength(1) ;c++){
                    float output = A[r,c] + B[r,c];
                    Console.Write("{0:0.0} ",output);
                }
                PrintN("");
            }
        }
        static void NegativeOfMatrix(float[,] A,float[,] B){
            for (int r = 0;r < A.GetLength(0) ;r++){
                for (int c = 0;c < A.GetLength(1) ;c++){
                    float output = A[r,c] - B[r,c];
                    Console.Write("{0:0.0} ",output);
                }
                PrintN("");
            }
        }

        static void SetMetrixValue(ref float[,] Matrix){
            for (int r = 0;r < Matrix.GetLength(0) ;r++){
                for (int c = 0;c < Matrix.GetLength(1) ;c++){
                    Console.Write("Input value at [{0},{1}]: ",r,c);
                    Matrix[r,c] = float.Parse(Console.ReadLine()) ;
                }
            }
        }
    }

    static void Nhong888(){
        int n = Get_Numder("Input N: ",1,10000); // Roll
        int k = Get_Numder("Input K: ",1,100); // Distance
        
        int [] peoples = new int[n];

        for (int i = 0;i < n; i++){
            peoples[i] = Get_Numder("People in this Area: ",0,500);
        }

        int max = 0;
    
        for (int i = 0;i < n; i++){
            int sum = Get_People_In_Distance(peoples,i,k);
            if ( sum > max) {
                max = sum;   
            }
        }

        PrintN("Highesr customer that posible is: " + max);

        static int Get_People_In_Distance(int [] peoples,int pos ,int K){
            int sum = 0;
            for (int i = (pos - K) ;i <= (pos + K); i++){
                if ((i >= 0 && i < peoples.GetLength(0))  ){
                    sum += peoples[i];
                }

            }
            return sum;
        }


        static int Get_Numder(string text, int min,int max){
            Print(text);
            int number = int.Parse(Console.ReadLine());
            if (number < min || number > max) {
                return Get_Numder(text,min,max);
            }
            return number;
        }
    }


    static void Select_Action(){
        PrintN("1 PascalTriangle");
        PrintN("2 DNA");
        PrintN("3 Legendary Metrix");
        PrintN("4 Nhong888");
        Print("Type to select Option you want: ");

        char selection  = Convert.ToChar(Console.ReadLine());

        switch (selection){
            case '1':
                PascalTriangle();
                break;
            case '2':
                DNA();
                break;
            case '3':
                Legendary_Metrix();
                break;
            case '4':
                Nhong888();
                break;
        }
        
        PrintN("");
        Print("Did u want to continue [Y/N]: ");

        selection  = Convert.ToChar(Console.ReadLine());
        switch (selection){
            case 'Y':
                Console.Clear();
                Select_Action();
                break;
            default:
                PrintN("End.");
                break;
        }

    }

    static void Main(string[] args){
       Select_Action();
    }
}