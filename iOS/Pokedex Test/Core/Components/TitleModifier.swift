//
//  TitleModifier.swift
//  Pokedex Test
//
//  Created by Martin on 28/07/23.
//

import SwiftUI

struct TitleModifier: ViewModifier {
    func body(content: Content) -> some View {
        content
            .font(.custom("GILROY-BOLD", size: 20))
    }
}
