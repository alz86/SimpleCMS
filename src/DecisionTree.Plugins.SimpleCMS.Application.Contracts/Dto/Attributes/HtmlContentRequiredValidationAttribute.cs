using HtmlAgilityPack;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Linq;

namespace DecisionTree.Plugins.SimpleCMS.Dto.Attributes
{
    /// <summary>
    /// Validates that the provided HTML content includes meaningful elements for display
    /// (non-empty text or images).
    /// <remarks>
    /// The purpose of this validator is to ensure the field contains 
    /// more than just empty HTML tags.
    /// </remarks>
    public class HtmlContentRequiredValidationAttribute : ValidationAttribute
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            var htmlContent = value as string;
            if (!string.IsNullOrWhiteSpace(htmlContent))
            {
                try
                {
                    var doc = new HtmlDocument();
                    doc.LoadHtml(htmlContent);

                    // Checks for existing visible text
                    bool hasVisibleText = doc.DocumentNode
                        .Descendants()
                        .Any(n => n.NodeType == HtmlNodeType.Text && !string.IsNullOrWhiteSpace(n.InnerText.Trim()));

                    bool? hasImages = null;
                    if (!hasVisibleText)
                    {
                        // we check for images only if we haven't found texts yet
                        hasImages = doc.DocumentNode
                            .Descendants("img")
                            .Any(img => img.Attributes.Contains("src") && !string.IsNullOrWhiteSpace(img.Attributes["src"].Value));

                    }

                    if (hasVisibleText || (hasImages == true)) return ValidationResult.Success!;
                }
                catch
                {
                    //invalid content
                }
            }
            return new ValidationResult($"Content of field \"{validationContext.DisplayName}\" is empty.");
        }
    }
}