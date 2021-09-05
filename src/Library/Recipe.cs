//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }
            Console.WriteLine($"El costo total de la receta es:{this.GetProductionCost()}");
        }
        /* 
        Decidimos asignar esta responsabilidad a la clase Recipe basándonos en el patrón Expert. Para este metodo se
        necesita información sobre: los pasos, la cantidad de productos, el costo por unidad, el equipamiento, el costo 
        por hora del equipamiento y el timepo de uso. La única clase que tiene información sobre todo eso es Recipe. 
        */
        public double GetProductionCost()
        {
            double CostoInsumos = 0;
            double CostoEquipamiento = 0;
            foreach (Step step in this.steps)
            {
                CostoInsumos += step.Input.UnitCost * step.Quantity;
                CostoEquipamiento += step.Equipment.HourlyCost * Convert.ToDouble(step.Time);
            }
            return CostoEquipamiento + CostoInsumos;
        }
    }
}