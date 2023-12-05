//
//  MoveView.swift
//  Pokedex Test
//
//  Created by Martin on 28/07/23.
//

import SwiftUI

struct MoveView: View {
    let move: Move
    var body: some View {
        ZStack {
            RoundedRectangle(cornerRadius: 14)
                .foregroundColor(.white)
                .shadow(color: .gray.opacity(0.2), radius: 5, x: 0, y: 0)
            HStack {
                Text(move.name.capitalized)
                    .font(.custom("GILROY-REGULAR", size: 12))
                Spacer()
                Image(move.type.img)
                    .resizable()
                    .scaledToFill()
                    .frame(width: 15,height: 15)
            }
            .padding(.horizontal)
            
        }
        .frame(width: 160, height: 37)
    }
}

struct MoveView_Previews: PreviewProvider {
    static var previews: some View {
        MoveView(move: Move.MOCK_MOVE[0])
    }
}
