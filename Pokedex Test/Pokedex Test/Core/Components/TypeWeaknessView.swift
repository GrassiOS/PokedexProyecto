//
//  TypeWeaknessView.swift
//  Pokedex Test
//
//  Created by Martin on 28/07/23.
//

import SwiftUI

struct TypeWeaknessView: View {
    let title: String
    let type: PokemonType
    var body: some View {
        VStack(alignment:.leading,spacing: 10) {
            Text(title)
                .modifier(TitleModifier())
            HStack {
                Text(type.name.capitalized)
                    .font(.custom("GILROY-MEDIUM", size: 15))
                
                Image(type.img)
                    .resizable()
                    .scaledToFill()
                    .frame(width: 15,height: 15)
            }
        }
        .frame(maxWidth: .infinity, alignment: .leading)
        .padding(.horizontal)
    }
}

struct TypeWeaknessView_Previews: PreviewProvider {
    static var previews: some View {
        TypeWeaknessView(title: "Type", type: PokemonType(id: 1,name: "normal", img: "normal"))
    }
}
