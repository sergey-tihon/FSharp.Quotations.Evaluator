﻿// (c) Microsoft Corporation 2005-2009.

namespace FSharp.Quotations.Evaluator

    open System
    open System.Linq.Expressions

    module ExtraHashCompare =
        /// An intrinsic for compiling <c>&lt;@ x <> y @&gt;</c> to expression trees
        val GenericNotEqualIntrinsic : 'T -> 'T -> bool

    [<Sealed>]
    type QuotationEvaluator = 

        /// Convert the quotation expression to LINQ expression trees
        ///
        /// This operation will only succeed for a subset of quotation expressions.
        ///
        /// Exceptions: InvalidArgumentException will be raised if the input expression is
        /// not in the subset that can be converted to a LINQ expression tree
        static member ToLinqExpression : Microsoft.FSharp.Quotations.Expr -> System.Linq.Expressions.Expression

        /// Compile the quotation expression by first converting to LINQ expression trees
        /// The expression is currently always compiled.
        ///
        /// Exceptions: InvalidArgumentException will be raised if the input expression is
        /// not in the subset that can be converted to a LINQ expression tree
        static member CompileUntyped : Microsoft.FSharp.Quotations.Expr -> obj

        /// Compile the quotation expression by first converting to LINQ expression trees
        ///
        /// Exceptions: InvalidArgumentException will be raised if the input expression is
        /// not in the subset that can be converted to a LINQ expression tree
        static member EvaluateUntyped : Microsoft.FSharp.Quotations.Expr -> obj

        static member internal EvaluateUntypedUsingQueryApproximations : Microsoft.FSharp.Quotations.Expr -> obj
    
        /// Compile the quotation expression by first converting to LINQ expression trees
        /// The expression is currently always compiled.
        ///
        /// Exceptions: InvalidArgumentException will be raised if the input expression is
        /// not in the subset that can be converted to a LINQ expression tree
        static member Compile : Microsoft.FSharp.Quotations.Expr<'T> -> 'T

        /// Evaluate the quotation expression by first converting to LINQ expression trees
        ///
        /// Exceptions: InvalidArgumentException will be raised if the input expression is
        /// not in the subset that can be converted to a LINQ expression tree
        static member Evaluate : Microsoft.FSharp.Quotations.Expr<'T> -> 'T
        
    /// This module provides Compile and Eval extension members
    /// for F# quotation values, implemented by translating to LINQ
    /// expression trees and using the LINQ dynamic compiler.
    [<AutoOpen>]
    module QuotationEvaluationExtensions =

        type Microsoft.FSharp.Quotations.Expr with 
              /// Convert the quotation expression to a LINQ expression tree.
              ///
              /// Exceptions: InvalidArgumentException will be raised if the input expression is
              /// not in the subset that can be converted to a LINQ expression tree
              member ToLinqExpressionUntyped : unit -> Expression

        type Microsoft.FSharp.Quotations.Expr<'T> with 

              /// Compile and evaluate the quotation expression by first converting to LINQ expression trees.
              /// The expression is currently always compiled.
              ///
              /// Exceptions: InvalidArgumentException will be raised if the input expression is
              /// not in the subset that can be converted to a LINQ expression tree
              member Compile : unit -> 'T

              /// Evaluate the quotation expression by first converting to LINQ expression trees.
              /// The expression is currently always compiled.
              ///
              /// Exceptions: InvalidArgumentException will be raised if the input expression is
              /// not in the subset that can be converted to a LINQ expression tree
              member Evaluate : unit -> 'T

        type Microsoft.FSharp.Quotations.Expr with 

              /// Compile and evaluate the quotation expression by first converting to LINQ expression trees.
              ///
              /// Exceptions: InvalidArgumentException will be raised if the input expression is
              /// not in the subset that can be converted to a LINQ expression tree
              member CompileUntyped : unit -> obj

              /// Evaluate the quotation expression by first converting to LINQ expression trees.
              /// The expression is currently always compiled.
              ///
              /// Exceptions: InvalidArgumentException will be raised if the input expression is
              /// not in the subset that can be converted to a LINQ expression tree
              member EvaluateUntyped : unit -> obj

    module QuotationEvaluationTypes =
        /// This function should not be called directly. 
        //
        // NOTE: when an F# expression tree is converted to a Linq expression tree using ToLinqExpression 
        // the transformation of <c>LinqExpressionHelper(e)</c> is simple the same as the transformation of
        // 'e'. This allows LinqExpressionHelper to be used as a marker to satisfy the C# design where 
        // certain expression trees are constructed using methods with a signature that expects an
        // expression tree of type <c>Expression<T></c> but are passed an expression tree of type T.
        val LinqExpressionHelper : 'T -> Expression<'T>

        /// A set of types used for implementing quotation conversions.
        /// These are public only because targets of Linq Lambda expressions require them to be so
        module HelperTypes = 
            [<System.Obsolete("This type is for use by the quotation to LINQ expression tree converter and is not for direct use from user code")>]
            type ActionHelper<'T1,'T2,'T3,'T4,'T5,'T6,'T7,'T8,'T9,'T10, 'T11, 'T12, 'T13, 'T14, 'T15, 'T16, 'T17> = delegate of 'T1 * 'T2 * 'T3 * 'T4 * 'T5 * 'T6 * 'T7 * 'T8 * 'T9 * 'T10 * 'T11 * 'T12 * 'T13 * 'T14 * 'T15 * 'T16 * 'T17 -> unit
            [<System.Obsolete("This type is for use by the quotation to LINQ expression tree converter and is not for direct use from user code")>]
            type ActionHelper<'T1,'T2,'T3,'T4,'T5,'T6,'T7,'T8,'T9,'T10, 'T11, 'T12, 'T13, 'T14, 'T15, 'T16, 'T17, 'T18> = delegate of 'T1 * 'T2 * 'T3 * 'T4 * 'T5 * 'T6 * 'T7 * 'T8 * 'T9 * 'T10 * 'T11 * 'T12 * 'T13 * 'T14 * 'T15 * 'T16 * 'T17 * 'T18 -> unit
            [<System.Obsolete("This type is for use by the quotation to LINQ expression tree converter and is not for direct use from user code")>]
            type ActionHelper<'T1,'T2,'T3,'T4,'T5,'T6,'T7,'T8,'T9,'T10, 'T11, 'T12, 'T13, 'T14, 'T15, 'T16, 'T17, 'T18, 'T19> = delegate of 'T1 * 'T2 * 'T3 * 'T4 * 'T5 * 'T6 * 'T7 * 'T8 * 'T9 * 'T10 * 'T11 * 'T12 * 'T13 * 'T14 * 'T15 * 'T16 * 'T17 * 'T18 * 'T19 -> unit
            [<System.Obsolete("This type is for use by the quotation to LINQ expression tree converter and is not for direct use from user code")>]
            type ActionHelper<'T1,'T2,'T3,'T4,'T5,'T6,'T7,'T8,'T9,'T10, 'T11, 'T12, 'T13, 'T14, 'T15, 'T16, 'T17, 'T18, 'T19, 'T20> = delegate of 'T1 * 'T2 * 'T3 * 'T4 * 'T5 * 'T6 * 'T7 * 'T8 * 'T9 * 'T10 * 'T11 * 'T12 * 'T13 * 'T14 * 'T15 * 'T16 * 'T17 * 'T18 * 'T19 * 'T20 -> unit

            [<System.Obsolete("This type is for use by the quotation to LINQ expression tree converter and is not for direct use from user code")>]
            type FuncHelper<'T1,'T2,'T3,'T4,'T5,'T6,'T7,'T8,'T9,'T10, 'T11, 'T12, 'T13, 'T14, 'T15, 'T16, 'T17, 'T18> = delegate of 'T1 * 'T2 * 'T3 * 'T4 * 'T5 * 'T6 * 'T7 * 'T8 * 'T9 * 'T10 * 'T11 * 'T12 * 'T13 * 'T14 * 'T15 * 'T16 * 'T17 -> 'T18 
            [<System.Obsolete("This type is for use by the quotation to LINQ expression tree converter and is not for direct use from user code")>]
            type FuncHelper<'T1,'T2,'T3,'T4,'T5,'T6,'T7,'T8,'T9,'T10, 'T11, 'T12, 'T13, 'T14, 'T15, 'T16, 'T17, 'T18, 'T19> = delegate of 'T1 * 'T2 * 'T3 * 'T4 * 'T5 * 'T6 * 'T7 * 'T8 * 'T9 * 'T10 * 'T11 * 'T12 * 'T13 * 'T14 * 'T15 * 'T16 * 'T17 * 'T18 -> 'T19 
            [<System.Obsolete("This type is for use by the quotation to LINQ expression tree converter and is not for direct use from user code")>]
            type FuncHelper<'T1,'T2,'T3,'T4,'T5,'T6,'T7,'T8,'T9,'T10, 'T11, 'T12, 'T13, 'T14, 'T15, 'T16, 'T17, 'T18, 'T19, 'T20> = delegate of 'T1 * 'T2 * 'T3 * 'T4 * 'T5 * 'T6 * 'T7 * 'T8 * 'T9 * 'T10 * 'T11 * 'T12 * 'T13 * 'T14 * 'T15 * 'T16 * 'T17 * 'T18 * 'T19 -> 'T20 
            [<System.Obsolete("This type is for use by the quotation to LINQ expression tree converter and is not for direct use from user code")>]
            type FuncHelper<'T1,'T2,'T3,'T4,'T5,'T6,'T7,'T8,'T9,'T10, 'T11, 'T12, 'T13, 'T14, 'T15, 'T16, 'T17, 'T18, 'T19, 'T20, 'T21> = delegate of 'T1 * 'T2 * 'T3 * 'T4 * 'T5 * 'T6 * 'T7 * 'T8 * 'T9 * 'T10 * 'T11 * 'T12 * 'T13 * 'T14 * 'T15 * 'T16 * 'T17 * 'T18 * 'T19 * 'T20 -> 'T21 
