using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission {
    public string Objective { get; set; }
    public string Solution { get; set; }
    public bool Done { get; set; }

    public Mission(string objective, string solution = "مفيش حل", bool done = false) {
        this.Objective = objective;
        this.Solution = solution;
        this.Done = done;
    }
}
