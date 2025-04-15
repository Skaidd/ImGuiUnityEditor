using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Linq;

namespace ImGuiUnityEditor.CodeGen
{
    /// <summary>
    /// Syntax receiver that collects classes decorated with ImGuiMenuAttribute
    /// </summary>
    public class ImGuiMenuAttributeSyntaxReceiver : ISyntaxContextReceiver
    {
        public List<ClassDeclarationSyntax> CandidateClasses { get; } = [];

        public void OnVisitSyntaxNode(GeneratorSyntaxContext context)
        {
            if (context.Node is ClassDeclarationSyntax classDecl && classDecl.AttributeLists.Count > 0)
            {
                var symbol = context.SemanticModel.GetDeclaredSymbol(classDecl);
                if (symbol != null && HasImGuiMenuAttribute(symbol))
                {
                    CandidateClasses.Add(classDecl);
                }
            }
        }

        private bool HasImGuiMenuAttribute(ISymbol symbol)
        {
            return symbol.GetAttributes().Any(attr =>
                attr.AttributeClass?.Name == "ImGuiMenuAttribute" &&
                attr.AttributeClass?.ContainingNamespace?.ToDisplayString() == "ImGuiUnityEditor");
        }
    }
}

