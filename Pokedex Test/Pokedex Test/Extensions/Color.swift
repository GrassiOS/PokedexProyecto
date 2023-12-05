//
//  Color.swift
//  Pokedex Test
//
//  Created by Martin on 30/07/23.
//

import SwiftUI

extension Color {
    static func fromString(_ name: String) -> Color? {
        switch name.lowercased() {
        case "red": return .red.opacity(0.9)
        case "blue": return .blue.opacity(0.9)
        case "green": return .green.opacity(0.9)
        case "yellow": return .yellow.opacity(0.9)
        case "orange": return .orange.opacity(0.9)
        case "purple": return .purple.opacity(0.9)
        case "pink": return .pink.opacity(0.9)
        case "brown": return .brown.opacity(0.9)
        case "gray": return .gray.opacity(0.9)
        case "white": return .white.opacity(0.9)
        case "black": return .black.opacity(0.9)
            
        default: return nil
        }
    }
}
