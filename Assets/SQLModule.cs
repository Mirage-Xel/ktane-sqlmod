﻿using UnityEngine;

public class SQLModule : MonoBehaviour
{
    void Start()
    {
        Init();
    }

    void Init()
    {
        // Example of how to create a dataset
        DataSet dataSource = DataSetFactory.FromIntMatrix(DataSetFactory.dataSetMatrix1); // You can create other dataSetMatrix if you want and use them
        DataSet dataSource2 = DataSetFactory.FromRandomData(); // You can also change the number of rows

        // Example of how to create a query, you must bind the user's interaction into into making such a query
        DataQuery userQuery = new DataQuery();
        userQuery.selections.Add(new DataQuerySelection(DataRowColumnEnum.ColumnA));
        userQuery.selections.Add(new DataQuerySelection(DataRowColumnEnum.ColumnB));
        userQuery.selections.Add(new DataQuerySelection(DataRowColumnEnum.ColumnC, DataQueryAggregatorEnum.Count));
        userQuery.filter = new DataQueryFilter(DataRowColumnEnum.ColumnD, DataRowFilterOperatorEnum.OperatorGreaterThan, DataRowColumnEnum.ColumnE);
        userQuery.filter = new DataQueryFilter(DataRowColumnEnum.ColumnF, DataRowFilterOperatorEnum.OperatorGreaterThan, 6);
        userQuery.group.column = DataRowNoneColumnEnum.ColumnC;
        userQuery.limits.linesSkiped = 7;
        userQuery.limits.linesTaken = 2;

        // Another way to generate a query is using the data query generator which is how you create the target solution
        DataQuery targetQuery = DataQueryGenerator.GenerateSimple(dataSource);
        DataSet targetDataSet = targetQuery.Apply(dataSource);

        // Compare the DataSets together to validate if the solution is right
        if (dataSource.CompareTo(dataSource2))
        {
            // Valid
        }

    }
}
