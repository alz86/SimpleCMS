import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

/**
 * Validation functions that checks if a control of type ngx-editor
 * has content on it. Note that this validation checks the existence of
 * text content, not merely the presence of HTML tags. Thus, if only
 * images were include, it would consider as if it don't have any contents.
 */
export function ngxEditorRequiredValidator(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    const value = control.value;
    const doc = new DOMParser().parseFromString(value, 'text/html');
    const text = doc.body.textContent || '';
    if (text.trim().length === 0) {
      return { required: true };
    }
    return null;
  };
}
