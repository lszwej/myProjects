using Irony.Parsing;
using Irony;
using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MagisterkaBiblioteka
{
    class MagisterkaGrammar : Grammar
    {
        private ParseTree tree;

        public MagisterkaGrammar() : base(false)
        {
            NumberLiteral numberLiteral = new NumberLiteral("numberLiteral");
            NumberLiteral limitLiteral = new NumberLiteral("limitLiteral", NumberOptions.IntOnly, typeof(uint));
            StringLiteral stringLiteral = new StringLiteral("stringLiteral", "\"");
            KeyTerm SELECT = ToTerm("SELECT");
            KeyTerm ALL = ToTerm("ALL");
            KeyTerm SORT = ToTerm("SORT");
            KeyTerm ASC = ToTerm("ASC");
            KeyTerm DESC = ToTerm("DESC");
            KeyTerm FROM = ToTerm("FROM");
            KeyTerm TOP = ToTerm("TOP");
            KeyTerm LIMIT = ToTerm("LIMIT");
            KeyTerm LJ = ToTerm("LJ");
            KeyTerm RJ = ToTerm("RJ");
            KeyTerm IJ = ToTerm("IJ");
            KeyTerm ON = ToTerm("ON");
            KeyTerm ADD = ToTerm("ADD");
            KeyTerm COLUMNS = ToTerm("COLUMNS");
            KeyTerm VALUES = ToTerm("VALUES");
            KeyTerm FOR = ToTerm("FOR");
            KeyTerm MODIFY = ToTerm("MODIFY");
            KeyTerm REMOVE = ToTerm("REMOVE");
            KeyTerm WHERE = ToTerm("WHERE");
            KeyTerm AND = ToTerm("AND");
            KeyTerm OR = ToTerm("OR");
            KeyTerm NOT = ToTerm("NOT");
            KeyTerm BETWEEN = ToTerm("BETWEEN");
            KeyTerm LIKE = ToTerm("LIKE");
            KeyTerm IN = ToTerm("IN");
            KeyTerm IS = ToTerm("IS");
            KeyTerm NULL = ToTerm("NULL");
            KeyTerm EXISTS = ToTerm("EXISTS");
            KeyTerm dot = ToTerm(".");
            KeyTerm comma = ToTerm(",");
            KeyTerm semi = ToTerm(";");

            IdentifierTerminal sqlIdentifier = TerminalFactory.CreateSqlExtIdentifier(this, "sqlIdentifier");
            NonTerminal identifier = new NonTerminal("identifier");
            NonTerminal expression = new NonTerminal("expression");
            NonTerminal simpleType = new NonTerminal("simpleType");
            NonTerminal statement = new NonTerminal("statement");
            NonTerminal selectStatement = new NonTerminal("selectStatement");
            NonTerminal columnList = new NonTerminal("columnsList");
            NonTerminal columnListItem = new NonTerminal("columnsListItem");
            NonTerminal columnInsertList = new NonTerminal("columnInsertList");
            NonTerminal addStatement = new NonTerminal("addStatement");
            NonTerminal valueList = new NonTerminal("valuesList");
            NonTerminal valueListItem = new NonTerminal("valueListItem");
            NonTerminal joinClause = new NonTerminal("joinClause");
            NonTerminal joinQuery = new NonTerminal("joinQuery");
            NonTerminal joinItem = new NonTerminal("joinItem");
            NonTerminal joinType = new NonTerminal("joinType");
            NonTerminal sortClause = new NonTerminal("sortClause");
            NonTerminal sortQuery = new NonTerminal("sortQuery");
            NonTerminal sortType = new NonTerminal("sortType");
            NonTerminal limitClause = new NonTerminal("limitClause");
            NonTerminal limitType = new NonTerminal("limitType");
            NonTerminal modifyStatement = new NonTerminal("modifyStatement");
            NonTerminal modifyList = new NonTerminal("modifyList");
            NonTerminal modifyListItem = new NonTerminal("modifyListItem");
            NonTerminal forClause = new NonTerminal("forClause");
            NonTerminal removeStatement = new NonTerminal("removeStatement");
            NonTerminal fromClause = new NonTerminal("fromClause");
            NonTerminal whereClause = new NonTerminal("whereClause");
            NonTerminal subquery = new NonTerminal("subquery");
            NonTerminal condition = new NonTerminal("condition");
            NonTerminal conditionExpression = new NonTerminal("conditionExpression");
            NonTerminal condtionOperators = new NonTerminal("condtionOperators");
            NonTerminal nullCondition = new NonTerminal("nullCondition");
            NonTerminal betweenCondition = new NonTerminal("betweenCondition");
            NonTerminal existsCondtion = new NonTerminal("existsCondition");
            NonTerminal inCondition = new NonTerminal("inCondition");
            NonTerminal inArray = new NonTerminal("inArray");
            NonTerminal negateOperator = new NonTerminal("negateOperator");

            statement.Rule = (selectStatement | addStatement | modifyStatement | removeStatement) + semi;
            identifier.Rule = MakePlusRule(identifier, dot, sqlIdentifier);

            // SELECT
            selectStatement.Rule = SELECT + limitClause + columnList + fromClause + joinClause + whereClause + sortClause;
            columnList.Rule = "{" + columnListItem + "}" | ALL;
            columnListItem.Rule = MakePlusRule(columnListItem, comma, identifier);
            fromClause.Rule = FROM + identifier;
            // JOIN
            joinClause.Rule = Empty | joinQuery;
            joinQuery.Rule = joinType + identifier + ON + identifier + "=" + identifier;
            joinType.Rule = IJ | LJ | RJ;
            // ORDER BY
            sortClause.Rule = Empty | SORT + "{" + sortQuery + "}";
            sortQuery.Rule = MakePlusRule(sortQuery, comma, identifier + sortType);
            sortType.Rule = Empty | ASC | DESC;
            // TOP/LIMIT
            limitClause.Rule = Empty | limitType + limitLiteral;
            limitType.Rule = LIMIT | TOP;

            // INSERT
            addStatement.Rule = ADD + forClause + columnInsertList + valueList;
            forClause.Rule = FOR + identifier;
            columnInsertList.Rule = "(" + columnListItem  + ")";
            valueList.Rule = (VALUES + "(" + valueListItem + ")") | selectStatement;
            valueListItem.Rule = MakePlusRule(valueListItem, comma, (simpleType | subquery));

            // UPDATE
            modifyStatement.Rule = MODIFY + forClause + COLUMNS + modifyList + whereClause;
            modifyList.Rule = MakePlusRule(modifyList, comma, modifyListItem);
            modifyListItem.Rule = identifier + "=" + (simpleType | subquery);

            // DELETE
            removeStatement.Rule = REMOVE + fromClause + whereClause;

            // WHERE
            whereClause.Rule = Empty | WHERE + negateOperator + expression;
            expression.Rule = simpleType | conditionExpression;
            simpleType.Rule = identifier| numberLiteral | stringLiteral;
            condition.Rule = expression + condtionOperators + (expression | subquery);
            conditionExpression.Rule = condition | nullCondition | betweenCondition | inCondition | existsCondtion;
            condtionOperators.Rule = AND + negateOperator | OR + negateOperator | negateOperator + LIKE | "=" | "<>" | ">" | ">=" | "<" | "<=";
            subquery.Rule = "(" + selectStatement + ")";
            nullCondition.Rule = expression + IS + negateOperator + NULL;
            betweenCondition.Rule = expression + negateOperator + BETWEEN + (simpleType | subquery) + AND + (simpleType | subquery);
            inCondition.Rule = expression + negateOperator + IN + "(" + (inArray | selectStatement) + ")";
            inArray.Rule = MakePlusRule(inArray, comma, simpleType);
            existsCondtion.Rule = negateOperator + EXISTS + subquery;
            negateOperator.Rule = Empty | NOT;
            Root = statement;
        }

        private string changeStrings(string elem)
        {
            if (elem.StartsWith("\""))
                return "\'" + elem.Substring(1, elem.Length - 2) + "\' ";
            switch (elem.ToLower())
            {
                case "columns":
                    return "set ";
                case "all":
                    return "* ";
                case "ij":
                    return "inner join ";
                case "lj":
                    return "left join ";
                case "rj":
                    return "right join ";
                case "sort":
                    return "order by ";
                case "{":
                case "}":
                    return "";
            }
            return elem + " ";
        }

        private string createSelect()
        {
            StringBuilder sqlQuery = new StringBuilder("select ");
            string limit = "";
            string number = "";
            for (int i = 1; i < tree.Tokens.Count; ++i)
            {
                string elem = "";
                if (tree.Tokens[i].Text.Equals("limit"))
                {
                    limit = tree.Tokens[i].Text;
                    number = tree.Tokens[i + 1].Text;
                }
                else
                    elem = changeStrings(tree.Tokens[i].Text);
                sqlQuery.Append(elem);
            }
            if (limit.Length > 0 && number.Length > 0)
                sqlQuery.Insert(sqlQuery.Length - 3, limit + " " + number);
            return sqlQuery.ToString();
        }

        private string createInsert()
        {
            StringBuilder sqlQuery = new StringBuilder("insert into ");
            for (int i = 2; i < tree.Tokens.Count; ++i)
            {
                string elem = changeStrings(tree.Tokens[i].Text);
                sqlQuery.Append(elem);
            }
            return sqlQuery.ToString();
        }

        private string createUpdate()
        {
            StringBuilder sqlQuery = new StringBuilder("update ");
            for (int i = 2; i < tree.Tokens.Count; ++i)
            {
                string elem = changeStrings(tree.Tokens[i].Text);
                sqlQuery.Append(elem);
            }
            return sqlQuery.ToString();
        }

        private string createDelete()
        {
            StringBuilder sqlQuery = new StringBuilder("delete ");
            for (int i = 1; i < tree.Tokens.Count; ++i)
            {
                string elem = changeStrings(tree.Tokens[i].Text);
                sqlQuery.Append(elem);
            }
            return sqlQuery.ToString();
        }

        private string changeToSql()
        {
            string sqlQuery = "";
            switch (tree.Tokens.First().Text.ToLower())
            {
                case "select":
                    sqlQuery = createSelect();
                    break;
                case "add":
                    sqlQuery = createInsert();
                    break;
                case "modify":
                    sqlQuery = createUpdate();
                    break;
                case "remove":
                    sqlQuery = createDelete();
                    break;

            }
            return sqlQuery;
        }

        public string ParseMetaLanguage(string text)
        {
            string sqlQuery = "";
            text = text.Trim();
            Parser parser = new Parser(this);
            tree = parser.Parse(text);
            if (!tree.HasErrors())
                sqlQuery = changeToSql();
            else
            {
                StringBuilder errors = new StringBuilder();
                foreach (LogMessage mess in tree.ParserMessages)
                    errors.Append(mess.Message + Environment.NewLine);
                MessageBox.Show(errors.ToString());
            }
            return sqlQuery;
        }
    }
}